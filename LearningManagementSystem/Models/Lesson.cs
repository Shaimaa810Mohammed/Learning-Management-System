namespace LearningManagementSystem.Models
{
	public class Lesson
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string OTP { get; set; }
		public ICollection<Media> MediaFiles { get; set; }

		public ICollection<Attendance>? Attendances { get; set; }

		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}
