using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;

namespace LearningManagementSystem.Repositories
{
	public class QuestionRepository : IQuestionRepository
	{
		private readonly DBContext _dbContext;
		public QuestionRepository(DBContext dBContext)
		{
			_dbContext = dBContext;
		}


		public void Add(Question question)
		{
			_dbContext.Add(question);
			_dbContext.SaveChanges();
		}

		public void Delete(Question question)
		{
			_dbContext.Remove(question);
			_dbContext.SaveChanges();
		}

		public Question? GetById(int id)
		{
			return _dbContext.Questions.FirstOrDefault(q => q.Id == id);
		}

		public List<Question> GetCourseQuestions(int courseId)
		{
			List<Question> questions = _dbContext.Questions.Where(q => q.CourseId == courseId).ToList();
			return questions;
		}

		public void Update(Question question)
		{
			_dbContext.Update(question);
			_dbContext.SaveChanges();
		}
	}
}
