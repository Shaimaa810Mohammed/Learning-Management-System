using LearningManagementSystem.Models;

namespace LearningManagementSystem.RepositoryContracts
{
	public interface IStudentRepository
	{
		void Delete(ApplicationUser student);

		ApplicationUser? GetById(string id);

	}
}
