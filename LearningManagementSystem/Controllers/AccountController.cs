using LearningManagementSystem.Enums;
using LearningManagementSystem.Models;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.Utils;
using LearningManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace LearningManagementSystem.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IEmailSenderService _emailSenderService;
		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSenderService emailSenderService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_emailSenderService = emailSenderService;
		}

		#region Admin Registration 

		[Authorize(Roles = "Admin")]
		public IActionResult AdminRegister()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AdminRegister(UserRegisterViewModel adminRegisterViewModel)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser admin = new ApplicationUser();
				admin.FName = adminRegisterViewModel.FirstName;
				admin.LName = adminRegisterViewModel.LastName;
				admin.UserName = adminRegisterViewModel.UserName;
				admin.Email = adminRegisterViewModel.Email;

				// Saving the admin to the database using UserManager
				IdentityResult createAdminResult = await _userManager.CreateAsync(admin, adminRegisterViewModel.Password);
				if (createAdminResult.Succeeded)
				{
					//////////////////////////////////// Assign Role to the user ///////////////////////////////
					IdentityResult addToRoleResult = await _userManager.AddToRoleAsync(admin, UserRoles.Admin.ToString());
					if (addToRoleResult.Succeeded)
					{
						await SendOtp(admin);
						return RedirectToAction("VerifyOtp", new {Id = admin.Id});
					}

					foreach (var error in addToRoleResult.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
				foreach (var error in createAdminResult.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View("AdminRegister", adminRegisterViewModel);
		}
		#endregion

		#region Instructor / Student Registration

		[HttpGet]
		public IActionResult UserRegister()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UserRegister(UserRegisterViewModel userRegisterViewModel, string userType)
		{
			if (string.IsNullOrEmpty(userType))
			{
				ModelState.AddModelError("", "select are you strudent or instructor");
				return View("UserRegister", userRegisterViewModel);
			}
			if (ModelState.IsValid)
			{
				ApplicationUser user = new ApplicationUser();
				user.FName = userRegisterViewModel.FirstName;
				user.LName = userRegisterViewModel.LastName;
				user.Email = userRegisterViewModel.Email;
				user.UserName = userRegisterViewModel.UserName;

				// save user in database
				IdentityResult createUserResult = await _userManager.CreateAsync(user, userRegisterViewModel.Password);
				if (createUserResult.Succeeded)
				{
					// assign role
					IdentityResult addToRoleResult = await _userManager.AddToRoleAsync(user, userType);
					if (addToRoleResult.Succeeded)
					{
						await SendOtp(user);
						return RedirectToAction("VerifyOtp", new { Id = user.Id }); // VerifyOtp -> HttpGet
					}

					foreach (var error in addToRoleResult.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
				foreach (var error in createUserResult.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			ViewData["UserType"] = userType;
			return View("UserRegister", userRegisterViewModel);
		}

		#endregion

		#region  OTP

		private async Task SendOtp(ApplicationUser user)
		{
			// generate otp
			string otp = OTP.GenerateOtp();

			// save otp and expiration time in database
			user.Otp = otp;

			// UTC = Coordinated Universal Time
			// It is the global standard time used by systems worldwide.
			// think of it as “The same time for everyone, everywhere in the world”
			user.OtpExpiration = DateTime.UtcNow.AddMinutes(5); // otp valid for 5 minutes

			user.OtpTrials = 0;

			await _userManager.UpdateAsync(user);
			// send otp email to user
			await _emailSenderService.SendEmailAsync(user.Email, "Your OTP for LMS", $"Your OTP is: {otp}. It is valid for 5 minutes.");
		}


		[HttpGet]
		public async Task<IActionResult> VerifyOtp(string id)
		{
			ApplicationUser? user = await _userManager.FindByIdAsync(id);
			ViewBag.Email = user.Email; // used in VerifyOtp view
			return View(new VerifyOtpViewModel() { Id = id });
		}

		[HttpPost]
		public async Task<IActionResult> VerifyOtp(VerifyOtpViewModel verifyOtpViewModel)
		{
			ApplicationUser? user = await _userManager.FindByIdAsync(verifyOtpViewModel.Id);
			if (user == null)
			{
				return NotFound("Invalid ID");
			}

			// otp expired
			if (user.OtpExpiration < DateTime.UtcNow)
			{
				return RedirectToAction("ResendOtpButton", new { Id = user.Id, error = "OTP expired, Retry Again. Click on Resend OTP" });
			}

			// wrong otp
			if (user.Otp != verifyOtpViewModel.OTP)
			{
				user.OtpTrials++;
				if (user.OtpTrials >= 3)
				{
					user.Otp = null;
					user.OtpExpiration = null;
					user.OtpTrials = 0;
					await _userManager.UpdateAsync(user);
					return RedirectToAction("ResendOtpButton", new { Id = user.Id, error = "Too many trials, Retry Again. Click on Resend OTP" });
				}
				await _userManager.UpdateAsync(user);
				ModelState.AddModelError("", "Invalid OTP");
				ViewBag.Email = user.Email; // used in VerifyOtp view
				return View(verifyOtpViewModel);
			}

			// valid otp
			user.EmailConfirmed = true;
			user.Otp = null;
			user.OtpExpiration = null;
			user.OtpTrials = 0;
			await _userManager.UpdateAsync(user);
			// create cookie
			await _signInManager.SignInAsync(user, isPersistent: false);
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult ResendOtpButton(string id, string error)
		{
			ViewBag.Id = id;
			ModelState.AddModelError("", error);
			// open view contains a button to resend otp 
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResendOtp(string id)
		{
			ApplicationUser? user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound("Invalid ID");
			}
			await SendOtp(user);
			return RedirectToAction("VerifyOtp", new { Id = id });
		}

		#endregion

		#region Login

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel)
		{
			if (ModelState.IsValid)
			{
				// check 
				ApplicationUser? appUser = await _userManager.FindByNameAsync(loginUserViewModel.UserName);
				if (appUser != null)
				{
					bool found = await _userManager.CheckPasswordAsync(appUser, loginUserViewModel.Password);
					if (found)
					{
						// create cookie
						await _signInManager.SignInAsync(appUser, loginUserViewModel.RememberMe);
						return RedirectToAction("Index", "Home");
					}
				}
				ModelState.AddModelError("", "User Name or Password wrong");
			}
			return View("Login", loginUserViewModel);
		}

		#endregion

		#region  Logout
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}

		#endregion

		#region Update User

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> UpdateUser()
		{
			string? id = User.FindFirstValue(ClaimTypes.NameIdentifier);
			ApplicationUser? user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound("Invalid ID");
			}
			UpdateUserViewModel model = new UpdateUserViewModel();
			model.FirstName = user.FName;
			model.LastName = user.LName;
			model.UserName = user.UserName;
			model.Email = user.Email;
			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> UpdateUser(UpdateUserViewModel updateUserViewModel)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser? user = await _userManager.FindByEmailAsync(updateUserViewModel.Email);
				if (user == null)
				{
					return NotFound("Invalid Email");
				}
				user.FName = updateUserViewModel.FirstName;
				user.LName = updateUserViewModel.LastName;
				user.UserName = updateUserViewModel.UserName;
				IdentityResult updateResult = await _userManager.UpdateAsync(user);
				if (!updateResult.Succeeded)
				{
					foreach (var error in updateResult.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}
			return View("UpdateUser", updateUserViewModel);
		}

		#endregion


		#region Forget Password

		[HttpGet]
		public IActionResult ForgetPassword()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser? user = await _userManager.FindByEmailAsync(model.Email);
				if (user == null)
				{
					return RedirectToAction("ForgetPasswordConfirmation");  // show a message to check email without revealing if the email exists or not
				}
				string token = await _userManager.GeneratePasswordResetTokenAsync(user);
				var resetLink = Url.Action("ResetPassword", "Account", new { Email = user.Email, Token = token }, Request.Scheme); // (actionName, controllerName, routeValues, protocol)
				var safeResetLink = HtmlEncoder.Default.Encode(resetLink);

				string body = $@"
						<h3>Password Reset</h3>
						<p>Click the link below to reset your password:</p>
						<a href='{safeResetLink}'>Reset Password</a>
						<p>If you did not request this, ignore this email.</p>
						";

				string subject = "Password Reset for LMS";

				await _emailSenderService.SendEmailAsync(model.Email, subject, body);
				return RedirectToAction("ForgetPasswordConfirmation");
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult ForgetPasswordConfirmation()
		{
			return View();
		}


		[HttpGet]
		public IActionResult ResetPassword(string email, string token)
		{
			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
			{
				return BadRequest("Invalid password reset token.");
			}
			ResetPasswordViewModel model = new ResetPasswordViewModel { Email = email, Token = token };
			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser? user = await _userManager.FindByEmailAsync(model.Email);
				if (user == null)
				{
					return RedirectToAction("ResetPasswordConfirmation");
				}
				IdentityResult resetPasswordResult = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
				if (resetPasswordResult.Succeeded)
				{
					// best practice: logout from all devices
					await _userManager.UpdateSecurityStampAsync(user);
					await _signInManager.SignOutAsync();
					return RedirectToAction("ResetPasswordConfirmation");
				}
				foreach (var error in resetPasswordResult.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(model);
		}

		public IActionResult ResetPasswordConfirmation()
		{
			return View();
		}



		#endregion

	}
}
