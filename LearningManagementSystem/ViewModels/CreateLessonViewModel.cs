using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.ViewModels
{
	public class CreateLessonViewModel
	{
		[StringLength(100, MinimumLength = 2)]
		public string Title { get; set; }



		[Required]
		[Display(Name = "Media Files")]
		public List<IFormFile> MediaFiles { get; set; }


		public int CourseId { get; set; }
	}
}
