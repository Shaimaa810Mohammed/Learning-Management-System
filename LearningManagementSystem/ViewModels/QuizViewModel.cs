using LearningManagementSystem.Constraint;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.ViewModels
{
	public class QuizViewModel
	{
		[Display (Name = "Start Time")]
		public DateTime StartTime { get; set; }


		[Display (Name = "End Time")]
		[CompareWithStartTime]
		public DateTime EndTime { get; set; }


		[StringLength(200, MinimumLength = 2)]
		public string Title { get; set; }

		public int CourseId { get; set; }

		public List<int> SelectedQuestionsIds { get; set; }
	}
}
