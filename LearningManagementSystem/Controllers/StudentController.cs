using LearningManagementSystem.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudentService _studentService;
		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}
		//public IActionResult Index()
		//{
		//	return View();
		//}


		public IActionResult DeleteStudent(string studentId)
		{
			_studentService.Delete(studentId);
			return RedirectToAction("Index", "Course");
		}
	}
}
