using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;

namespace LearningManagementSystem.Repositories
{
	public class QuizSubmissionRepository : IQuizSubmissionRepository
	{
		private readonly DBContext _dbContext;
		public QuizSubmissionRepository(DBContext dBContext)
		{
			_dbContext = dBContext;
		}

		public void Add(Models.QuizSubmission quizSubmission)
		{
			_dbContext.Add(quizSubmission);
			_dbContext.SaveChanges();
		}
	}
}
