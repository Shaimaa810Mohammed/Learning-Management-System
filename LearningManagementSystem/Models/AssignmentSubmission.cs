namespace LearningManagementSystem.Models
{
	public class AssignmentSubmission
	{
		public string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public int AssignmentId { get; set; }
		public Assignment Assignment { get; set; }

		public string SolutionFilePath { get; set; }

		public int Degree { get; set; }

		public bool IsChecked { get; set; }

		public DateTime SubmittedAt { get; set; }

	}
}
