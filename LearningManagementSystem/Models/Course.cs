namespace LearningManagementSystem.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int duration { get; set; }

		public string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		public ICollection<Enrollment>? Enrollments { get; set; }

		public ICollection<Lesson>? Lessons { get; set; }

		public ICollection<Assignment>? Assignments { get; set; }

		public ICollection<Quiz>? Quizzes { get; set; }

		public ICollection<Question>? Questions { get; set; }
	}
}
