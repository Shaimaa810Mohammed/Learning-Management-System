using LearningManagementSystem.Models;

namespace LearningManagementSystem.ServiceContracts
{
	public interface IMediaService
	{
		void Add(IFormFile file, int lessonId);

		void Delete(int mediaId);

		Media GetById(int id);
	}
}
