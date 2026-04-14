namespace LearningManagementSystem.Models
{
	public class Assignment : Assessment
	{
		public string AssignmentFilePath { get; set; }
		public string AssignmentFileName { get; set; }
		public ICollection<AssignmentSubmission>? AssignmentSubmissions { get; set; }
	}
}
