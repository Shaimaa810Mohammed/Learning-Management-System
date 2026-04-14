using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using LearningManagementSystem.ServiceContracts;

namespace LearningManagementSystem.Services
{
	public class StudentService : IStudentService
	{
		private readonly IStudentRepository _studentRepository;
		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}

		public void Delete(string studentId)
		{
			ApplicationUser? student = _studentRepository.GetById(studentId);

			_studentRepository.Delete(student);
		}
	}
}
