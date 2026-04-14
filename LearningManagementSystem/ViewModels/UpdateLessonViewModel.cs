using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.ViewModels
{
	public class UpdateLessonViewModel
	{
		[StringLength(100, MinimumLength = 2)]
		public string Title { get; set; }


		public int LessonId { get; set; }
	}
}
