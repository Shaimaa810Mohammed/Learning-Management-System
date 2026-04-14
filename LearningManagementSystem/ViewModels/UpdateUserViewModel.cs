using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.ViewModels
{
	public class UpdateUserViewModel
	{
		[Display(Name = "First Name")]
		[StringLength(50, MinimumLength = 3)]
		public string FirstName { get; set; }


		[Display(Name = "Last Name")]
		[StringLength(50, MinimumLength = 3)]
		public string LastName { get; set; }


		[StringLength(50, MinimumLength = 3)]
		public string UserName { get; set; }


		public string Email { get; set; }
	}
}
