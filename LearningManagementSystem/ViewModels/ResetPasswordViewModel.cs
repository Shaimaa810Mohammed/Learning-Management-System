using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.ViewModels
{
	public class ResetPasswordViewModel
	{
		[EmailAddress]
		public string Email { get; set; }

		public string Token { get; set; }


		[Display(Name = "New Password")]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }


		[Display(Name = "Confirm Password")]
		[Compare("NewPassword")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}
