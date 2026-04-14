using LearningManagementSystem.Models;

namespace LearningManagementSystem.RepositoryContracts
{
	public interface IAssignmentRepository
	{
		public void Add(Assignment assignment);
		public void Delete(Assignment assignment);

		public Assignment? GetById(int id);

		public void Update(Assignment assignment);

	}
}
