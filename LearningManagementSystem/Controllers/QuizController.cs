using LearningManagementSystem.Models;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearningManagementSystem.Controllers
{
	public class QuizController : Controller
	{
		private readonly IQuestionService _questionService;
		private readonly IQuizService _quizService;
		private readonly IQuizSubmissionService _quizSubmissionService;
		public QuizController(IQuestionService questionService, IQuizService quizService, IQuizSubmissionService quizSubmissionService)
		{
			_questionService = questionService;
			_quizService = quizService;
			_quizSubmissionService = quizSubmissionService;
		}

		[HttpGet]
		[Authorize(Roles ="Instructor")]
		public IActionResult CreateQuiz(int courseId)
		{
			ViewBag.courseId = courseId;
			List<Question> questions = _questionService.GetCourseQuestions(courseId);
			ViewBag.questions = questions;
			return View();
		}


		[HttpPost]
		[Authorize(Roles = "Instructor")]
		public IActionResult SaveCreate(QuizViewModel quizViewModel)
		{
			if (ModelState.IsValid)
			{
				_quizService.Add(quizViewModel);
				return RedirectToAction("Details", "Course", new { id = quizViewModel.CourseId });
			}
			ViewBag.courseId = quizViewModel.CourseId;
			ViewBag.questions = _questionService.GetCourseQuestions(quizViewModel.CourseId);
			return View("CreateQuiz", quizViewModel);
		}


		[HttpGet]
		[Authorize(Roles = "Instructor")]
		public IActionResult UpdateQuiz(int quizId)
		{
			Quiz quiz = _quizService.GetById(quizId);
			ViewBag.quizId = quizId;
			ViewBag.courseQuestions = _questionService.GetCourseQuestions(quiz.CourseId);
			ViewBag.quizQuestionsIds = _quizService.GetQuizQuestions(quizId).Select(qq => qq.QuestionId).ToList();
			QuizViewModel quizViewModel = new QuizViewModel
			{
				Title = quiz.Title,
				StartTime = quiz.StartTime,
				EndTime = quiz.EndTime,
				CourseId = quiz.CourseId,
			};
			return View(quizViewModel);
		}


		[HttpPost]
		[Authorize(Roles = "Instructor")]
		public IActionResult SaveUpdate(QuizViewModel quizViewModel, int quizId)
		{
			if (ModelState.IsValid)
			{
				_quizService.Update(quizViewModel, quizId);
				return RedirectToAction("Details", "Course", new { id = quizViewModel.CourseId });
			}
			ViewBag.quizId = quizId;
			ViewBag.courseQuestions = _questionService.GetCourseQuestions(quizViewModel.CourseId);
			ViewBag.quizQuestionsIds = _quizService.GetQuizQuestions(quizId).Select(qq => qq.QuestionId);
			return View("UpdateQuiz", quizViewModel);
		}


		[Authorize(Roles = "Student")]
		public IActionResult StartQuiz(int quizId)
		{
			Quiz quiz = _quizService.GetById(quizId);

			if (DateTime.Now >= quiz.StartTime && DateTime.Now < quiz.EndTime)
			{
				// open quiz for students
				List<Question> questions = _quizService.GetQuizQuestions(quizId).Select(qq => qq.Question).ToList();
				StartQuizViewModel startQuizViewModel = new StartQuizViewModel
				{
					Questions = questions,
					QuizId = quizId,
					StudentId = User.FindFirstValue(ClaimTypes.NameIdentifier),
					EndTime = quiz.EndTime
				};
				return View(startQuizViewModel);
			}
			else if (DateTime.Now < quiz.StartTime)
			{
				// show message that quiz is not started yet
				return BadRequest("Quiz is not started yet");
			}
			else
			{
				// show message that quiz is ended
				return BadRequest("Quiz is ended");
			}
		}


		[Authorize(Roles = "Student")]
		public IActionResult SubmitQuiz(SubmitQuizViewModel submitQuizViewModel)
		{
			if (DateTime.Now > submitQuizViewModel.EndTime)
			{
				return View("QuizEnded");
			}
			_quizSubmissionService.Add(submitQuizViewModel);
			return RedirectToAction("Details", "Course", new { id = _quizService.GetById(submitQuizViewModel.QuizId).CourseId });
		}
	
	}
}
