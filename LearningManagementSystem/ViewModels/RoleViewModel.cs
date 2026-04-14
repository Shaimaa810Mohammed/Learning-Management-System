using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LearningManagementSystem.ViewModels
{
	public class RoleViewModel
	{
		[Display(Name = "Role Name")]	
		public string RoleName { get; set; }
	}
}
