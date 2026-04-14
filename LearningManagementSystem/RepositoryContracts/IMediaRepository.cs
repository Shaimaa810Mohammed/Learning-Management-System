using LearningManagementSystem.Models;

namespace LearningManagementSystem.RepositoryContracts
{
	public interface IMediaRepository
	{
		void Add(Media media);

		void Delete(Media media);

		Media? GetById(int id);
	}
}
