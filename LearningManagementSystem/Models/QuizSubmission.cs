namespace LearningManagementSystem.Models
{
	public class QuizSubmission
	{
		public string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		public int QuizId { get; set; }
		public Quiz Quiz { get; set; }

		public List<string> StudentAnswers { get; set; }

		public int Degree { get; set; }

		public bool IsSubmitted { get; set; }
	}
}
