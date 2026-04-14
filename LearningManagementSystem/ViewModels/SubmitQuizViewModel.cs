using LearningManagementSystem.Models;

namespace LearningManagementSystem.ViewModels
{
	public class SubmitQuizViewModel
	{
		public int QuizId { get; set; }

		public string StudentId { get; set; }

		public DateTime EndTime { get; set; }

		public List<int> QuestionsId { get; set; }

		public List<string> StudentAnswers { get; set; }
	}
}
