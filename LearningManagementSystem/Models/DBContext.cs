using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Models
{
	public class DBContext : IdentityDbContext<ApplicationUser>
	{
		public DBContext(DbContextOptions<DBContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// one to many relation (create) between Instructor and Course
			builder.Entity<ApplicationUser>()
				.HasMany(u => u.Courses)
				.WithOne(c => c.ApplicationUser)
				.HasForeignKey(c => c.ApplicationUserId)
				.OnDelete(DeleteBehavior.Cascade);

			// set primary key for Enrollment table
			builder.Entity<Enrollment>()
				.HasKey(e => new { e.ApplicationUserId, e.CourseId });

			// one to many relation between ApplicationUser and Enrollment
			builder.Entity<Enrollment>()
				.HasOne(e => e.ApplicationUser)
				.WithMany(u => u.Enrollments)
				.HasForeignKey(e => e.ApplicationUserId)
				.OnDelete(DeleteBehavior.Restrict);

			// one to many relation between Course and Enrollment
			builder.Entity<Enrollment>()
				.HasOne(e => e.Course)
				.WithMany(u => u.Enrollments)
				.HasForeignKey(e => e.CourseId)
				.OnDelete(DeleteBehavior.Cascade);

			// set primary key for Attendance table
			builder.Entity<Attendance>()
				.HasKey(a => new { a.ApplicationUserId, a.LessonId });

			// one to many relation between ApplicationUser and Attendance
			builder.Entity<Attendance>()
				.HasOne(a => a.ApplicationUser)
				.WithMany(u => u.Attendances)
				.HasForeignKey(a => a.ApplicationUserId)
				.OnDelete(DeleteBehavior.Restrict);

			// one to many relation between Lesson and Attendance
			builder.Entity<Attendance>()
				.HasOne(a => a.Lesson)
				.WithMany(u => u.Attendances)
				.HasForeignKey(a => a.LessonId)
				.OnDelete(DeleteBehavior.Cascade);

			// one to many relation between ApplicationUser and Notification
			builder.Entity<Notification>()
				.HasOne(n => n.ApplicationUser)
				.WithMany(u => u.Notifications)
				.HasForeignKey(n => n.ApplicationUserId)
				.OnDelete(DeleteBehavior.Cascade);

			// set primary key for QuizSubmission table
			builder.Entity<QuizSubmission>()
				.HasKey(q => new { q.ApplicationUserId, q.QuizId });

			// one to many relation between ApplicationUser and QuizSubmission
			builder.Entity<QuizSubmission>()
				.HasOne(q => q.ApplicationUser)
				.WithMany(u => u.QuizSubmissions)
				.HasForeignKey(q => q.ApplicationUserId)
				.OnDelete(DeleteBehavior.Restrict);

			// one to many relation between Quiz and QuizSubmission
			builder.Entity<QuizSubmission>()
				.HasOne(q => q.Quiz)
				.WithMany(u => u.QuizSubmissions)
				.HasForeignKey(q => q.QuizId)
				.OnDelete(DeleteBehavior.Cascade);

			// set primary key for AssignmentSubmission table
			builder.Entity<AssignmentSubmission>()
				.HasKey(a => new { a.ApplicationUserId, a.AssignmentId });

			// one to many relation between ApplicationUser and AssignmentSubmission
			builder.Entity<AssignmentSubmission>()
				.HasOne(a => a.ApplicationUser)
				.WithMany(u => u.AssignmentSubmissions)
				.HasForeignKey(a => a.ApplicationUserId)
				.OnDelete(DeleteBehavior.Restrict);

			// one to many relation between Assignment and AssignmentSubmission
			builder.Entity<AssignmentSubmission>()
				.HasOne(a => a.Assignment)
				.WithMany(u => u.AssignmentSubmissions)
				.HasForeignKey(a => a.AssignmentId)
				.OnDelete(DeleteBehavior.Cascade);

			// one to many relation between course and lesson
			builder.Entity<Lesson>()
				.HasOne(l => l.Course)
				.WithMany(c => c.Lessons)
				.HasForeignKey(l => l.CourseId)
				.OnDelete(DeleteBehavior.Cascade);

			// one to many relation between course and assessment
			builder.Entity<Lesson>()
				.HasOne(l => l.Course)
				.WithMany(c => c.Lessons)
				.HasForeignKey(l => l.CourseId)
				.OnDelete(DeleteBehavior.Cascade);

			// one to many relation between course and question
			builder.Entity<Question>()
				.HasOne(q => q.Course)
				.WithMany(c => c.Questions)
				.HasForeignKey(q => q.CourseId)
				.OnDelete(DeleteBehavior.Restrict);


			builder.Entity<QuizQuestion>()
				.HasKey(q => new { q.QuizId, q.QuestionId });

		}

		public DbSet<Assessment> Assessments { get; set; }
		public DbSet<Assignment> Assignments { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Quiz> Quizzes { get; set; }
		public DbSet<Media> Medias { get; set; }

		public DbSet<Enrollment> Enrollments { get; set; }
		public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }
		public DbSet<QuizSubmission> QuizSubmissions { get; set; }
		public DbSet<QuizQuestion> QuizQuestions { get; set; }
	}
}
