using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using LearningManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Repositories
{
	public class LessonRepository : ILessonRepository
	{
		private readonly DBContext _dbcontext;
		public LessonRepository(DBContext dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public void Add(Lesson lesson)
		{
			_dbcontext.Add(lesson);
			_dbcontext.SaveChanges();
		}

		public void Delete(Lesson lesson)
		{
			_dbcontext.Remove(lesson);
			_dbcontext.SaveChanges();
		}

		public Lesson? GetById(int id)
		{
			Lesson? lesson = _dbcontext.Lessons.Include(l => l.MediaFiles).FirstOrDefault(l => l.Id == id);
			return lesson;
		}

		public void Update(Lesson oldLesson)
		{
			_dbcontext.Update(oldLesson);
			_dbcontext.SaveChanges();
		}
	}
}
