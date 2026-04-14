using LearningManagementSystem.Constraint;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.ViewModels
{
	public class AssignmentViewModel
	{
		[Display (Name = "Start Time")]
		public DateTime StartTime { get; set; }


		[Display (Name = "End Time")]
		[CompareWithStartTime]
		public DateTime EndTime { get; set; }


		[StringLength(200, MinimumLength = 2)]
		public string Title { get; set; }


		[Display (Name = "Maximum Degree")]
		[Range(1, 100)]
		public int MaxDegree { get; set; }


		[Display (Name = "Upload Assignment File")]
		public IFormFile AssignmentFile { get; set; }


		public int CourseId { get; set; }
	}
}
