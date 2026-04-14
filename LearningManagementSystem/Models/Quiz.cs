namespace LearningManagementSystem.Models
{
	public class Quiz : Assessment
	{
		public ICollection<QuizQuestion> QuizQuestions { get; set; }

		public ICollection<QuizSubmission>? QuizSubmissions { get; set; }
	}
}
