using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.ViewModels
{
	public class LoginUserViewModel
	{
		public string UserName { get; set; }


		[DataType(DataType.Password)]
		public string Password { get; set; }


		[Display(Name = "Remember Me")]
		public bool RememberMe { get; set; }
	}
}
