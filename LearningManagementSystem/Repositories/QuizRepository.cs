using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Repositories
{
	public class QuizRepository : IQuizRepository
	{
		private readonly DBContext _dbcontext;
		public QuizRepository(DBContext dbcontext)
		{
			_dbcontext = dbcontext;
		}


		public void Add(Quiz quiz)
		{
			_dbcontext.Add(quiz);
			_dbcontext.SaveChanges();
		}


		public void AddQuizQuestion(QuizQuestion quizQuestion)
		{
			_dbcontext.Add(quizQuestion);
			_dbcontext.SaveChanges();
		}

		public void Delete(Quiz quiz)
		{
			_dbcontext.Remove(quiz);
			_dbcontext.SaveChanges();
		}

		public void DeleteQuizQuestion(QuizQuestion quizQuestion)
		{
			_dbcontext.Remove(quizQuestion);
			_dbcontext.SaveChanges();
		}

		public Quiz? GetById(int id)
		{
			return _dbcontext.Quizzes.FirstOrDefault(q => q.Id == id);
		}

		public List<QuizQuestion> GetQuizQuestions(int quizId)
		{
			return _dbcontext.QuizQuestions.Include(qq => qq.Question).Where(qq => qq.QuizId == quizId).ToList();
		}

		public void Update(Quiz quiz)
		{
			_dbcontext.Update(quiz);
			_dbcontext.SaveChanges();
		}
	}
}
