using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Repositories
{
	public class AssignmentSubmissionRepository : IAssignmentSubmissionRepository
	{
		private readonly DBContext _dbContext;
		public AssignmentSubmissionRepository(DBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Add(AssignmentSubmission assignmentSubmission)
		{
			_dbContext.Add(assignmentSubmission);
			_dbContext.SaveChanges();
		}

		public AssignmentSubmission? GetById(int assignmentId, string studentId)
		{
			return _dbContext.AssignmentSubmissions.FirstOrDefault(s => s.AssignmentId == assignmentId && s.ApplicationUserId == studentId);
		}

		public List<AssignmentSubmission> GetUncheckedAssignmentSubmissions(int assignmentId)
		{
			List<AssignmentSubmission> submissions = _dbContext.AssignmentSubmissions.Include(s => s.ApplicationUser).Include(s => s.Assignment).Where(s => s.IsChecked == false && s.AssignmentId == assignmentId).ToList();
			return submissions;
		}

		public void Update(AssignmentSubmission assignmentSubmission)
		{
			_dbContext.Update(assignmentSubmission);
			_dbContext.SaveChanges();
		}
	}
}
