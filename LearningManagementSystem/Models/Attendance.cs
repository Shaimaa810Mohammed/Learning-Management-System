namespace LearningManagementSystem.Models
{
	public class Attendance
	{
		public string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		public int LessonId { get; set; }
		public Lesson Lesson { get; set; }
	}
}
