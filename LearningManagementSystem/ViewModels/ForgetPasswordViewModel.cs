using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.ViewModels
{
	public class ForgetPasswordViewModel
	{
		[EmailAddress]
		public string Email { get; set; }
	}
}
