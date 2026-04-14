using LearningManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.ViewModels
{
	public class QuestionViewModel
	{

		[StringLength(1000, MinimumLength =3)]
		public string QuestionText { get; set; }
		


		[Display(Name = "Question Type")]
		public QuestionType QuestionType { get; set; }



		[Display(Name = "Answer Options")]
		public List<string> AnswerOptions { get; set; }



		[Display(Name = "Correct Answer")]
		[StringLength(500, MinimumLength = 1)]
		public string CorrectAnswer { get; set; }



		[Display(Name = "Max Degree")]
		[Range(1, 100)]
		public int MaxDegree { get; set; }


		[Display(Name = "Courses")]
		public int CourseId { get; set; }
	}
}
