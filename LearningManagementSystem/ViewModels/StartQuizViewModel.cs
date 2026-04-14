using LearningManagementSystem.Models;

namespace LearningManagementSystem.ViewModels
{
	public class StartQuizViewModel
	{
		public int QuizId { get; set; }

		public string StudentId { get; set; }

		public List<Question> Questions { get; set; }

		public DateTime EndTime { get; set; }
	}
}
