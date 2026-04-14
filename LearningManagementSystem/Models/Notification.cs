namespace LearningManagementSystem.Models
{
	public class Notification
	{
		public int Id { get; set; }
		public string Message { get; set; }
		public bool IsRead { get; set; }

		public string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }	
	}
}
