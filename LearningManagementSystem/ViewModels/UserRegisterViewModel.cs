using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.ViewModels
{
	public class UserRegisterViewModel
	{
		[StringLength(50, MinimumLength =3)]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }


		[Display(Name = "Last Name")]
		[StringLength(50, MinimumLength = 3)]
		public string LastName { get; set; }


		[StringLength(50, MinimumLength = 3)]
		public string UserName { get; set; }


		[EmailAddress]
		public string Email { get; set; }


		[StringLength(20, MinimumLength = 6)]
		[DataType(DataType.Password)]
		public string Password { get; set; }


		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
	}
}
