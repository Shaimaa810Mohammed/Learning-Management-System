using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models
{
	public class Media
	{
		public int Id { get; set; }
		public string FilePath { get; set; }  // relative path to wwwroot
		public string FileName { get; set; }
		public string MediaType { get; set; } // video , audio, file


		[ForeignKey("Lesson")]
		public int LessonId { get; set; }
		public Lesson Lesson { get; set; }
	}
}
