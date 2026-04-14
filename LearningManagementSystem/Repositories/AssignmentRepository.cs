using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;

namespace LearningManagementSystem.Repositories
{
	public class AssignmentRepository : IAssignmentRepository
	{
		private readonly DBContext _dbcontext;
		public AssignmentRepository(DBContext dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public void Add(Assignment assignment)
		{
			_dbcontext.Add(assignment);
			_dbcontext.SaveChanges();
		}


		public void Delete(Assignment assignment)
		{
			_dbcontext.Remove(assignment);
			_dbcontext.SaveChanges();
		}

		public Assignment? GetById(int id)
		{
			return _dbcontext.Assignments.FirstOrDefault(a => a.Id == id);
		}

		public void Update(Assignment assignment)
		{
			_dbcontext.Update(assignment);
			_dbcontext.SaveChanges();
		}
	}
}
