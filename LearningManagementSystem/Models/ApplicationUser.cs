using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Models
{
	public class ApplicationUser : IdentityUser
	{
		// Email, Password and ID are inherited from IdentityUser
		// role -> Admin, Instructor, Student
		// role can be managed using ASP.NET Identity's RoleManager and UserManager
		public string FName { get; set; }
		public string LName { get; set; }

		[StringLength(20)] // max length for otp is 20 characters
		public string? Otp { get; set; }

		public DateTime? OtpExpiration { get; set; }

		public int? OtpTrials { get; set; }

		public ICollection<Course>? Courses { get; set; }

		public ICollection<Enrollment>? Enrollments { get; set; }

		public ICollection<Attendance>? Attendances { get; set; }

		public ICollection<Notification>? Notifications { get; set; }

		public ICollection<QuizSubmission>? QuizSubmissions { get; set; }

		public ICollection<AssignmentSubmission>? AssignmentSubmissions { get; set; }

	}
}
