using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.Repositories
{
	public class MediaRepository : IMediaRepository
	{
		private readonly DBContext _dbContext;
		public MediaRepository(DBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Add(Media media)
		{
			_dbContext.Add(media);
			_dbContext.SaveChanges();
		}

		public void Delete(Media media)
		{
			_dbContext.Remove(media);
			_dbContext.SaveChanges();
		}

		public Media? GetById(int id)
		{
			Media? media = _dbContext.Medias.Include(m => m.Lesson).FirstOrDefault(m => m.Id == id);
			return media;
		}
	}
}
