using LearningManagementSystem.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystem.Models
{
	public class Question
	{
		public int Id { get; set; }
		public string QuestionText { get; set; }
		public QuestionType QuestionType { get; set; }

		public List<string> AnswerOptions { get; set; }
		public string CorrectAnswer { get; set; }
		public int MaxDegree { get; set; }

		//public int? AssessmentId { get; set; }
		public ICollection<QuizQuestion>? QuizQuestions { get; set; }



		[ForeignKey("Course")]
		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}
