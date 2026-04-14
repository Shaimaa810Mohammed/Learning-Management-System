namespace LearningManagementSystem.Models
{
	public class Enrollment
	{
		public string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		public int CourseId { get; set; }
		public Course Course { get; set; }

	}
}
