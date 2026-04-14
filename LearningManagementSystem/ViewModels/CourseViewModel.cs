using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.ViewModels
{
	public class CourseViewModel
	{
		[StringLength(100, MinimumLength = 2)]
		public string Title { get; set; }


		[StringLength(500, MinimumLength = 2)]
		public string Description { get; set; }


		[Range(1, 500)]
		public int Duration { get; set; }
	}
}
