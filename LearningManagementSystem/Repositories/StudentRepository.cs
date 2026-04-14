using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;

namespace LearningManagementSystem.Repositories
{
	public class StudentRepository : IStudentRepository
	{
		private readonly DBContext _dbContext;
		public StudentRepository(DBContext dBContext)
		{
			_dbContext = dBContext;
		}

		public void Delete(ApplicationUser student)
		{
			_dbContext.Remove(student);
			_dbContext.SaveChanges();
		}

		public ApplicationUser? GetById(string id)
		{
			return _dbContext.Users.FirstOrDefault(s => s.Id == id);
		}
	}
}
