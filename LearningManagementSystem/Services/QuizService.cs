using LearningManagementSystem.Models;
using LearningManagementSystem.Repositories;
using LearningManagementSystem.RepositoryContracts;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.Services
{
	public class QuizService : IQuizService
	{
		private readonly IQuizRepository _quizRepository;
		private readonly IQuestionRepository _questionRepository;
		public QuizService(IQuizRepository quizRepository, IQuestionRepository questionRepository)
		{
			_quizRepository = quizRepository;
			_questionRepository = questionRepository;
		}

		public void Add(QuizViewModel quizViewModel)
		{
			int totalDegree = 0;
			foreach (var questionId in quizViewModel.SelectedQuestionsIds)
			{
				Question question = _questionRepository.GetById(questionId);
				totalDegree += question.MaxDegree;
			}
			Quiz quiz = new Quiz
			{
				Title = quizViewModel.Title,
				StartTime = quizViewModel.StartTime,
				EndTime = quizViewModel.EndTime,
				CourseId = quizViewModel.CourseId,
				TotalDegree = totalDegree
			};
			_quizRepository.Add(quiz);

			foreach (var questionId in quizViewModel.SelectedQuestionsIds)
			{
				QuizQuestion quizQuestion = new QuizQuestion
				{
					QuizId = quiz.Id,
					QuestionId = questionId
				};
				_quizRepository.AddQuizQuestion(quizQuestion);
			}
		}

		public void Delete(int id)
		{
			Quiz quiz = GetById(id);
			_quizRepository.Delete(quiz);
		}

		public Quiz GetById(int id)
		{
			return _quizRepository.GetById(id);
		}

		public List<QuizQuestion> GetQuizQuestions(int quizId)
		{
			return _quizRepository.GetQuizQuestions(quizId);
		}

		public void Update(QuizViewModel quizViewModel, int quizId)
		{
			int totalDegree = 0;
			foreach (var questionId in quizViewModel.SelectedQuestionsIds)
			{
				Question question = _questionRepository.GetById(questionId);
				totalDegree += question.MaxDegree;
			}

			// Update -> Quiz
			Quiz quiz = GetById(quizId);
			quiz.Title = quizViewModel.Title;
			quiz.StartTime = quizViewModel.StartTime;
			quiz.EndTime = quizViewModel.EndTime;
			quiz.TotalDegree = totalDegree;
			quiz.CourseId = quizViewModel.CourseId;
			_quizRepository.Update(quiz);

			// update -> QuizQuestion
			// get old QuizQuestions => added in create
			List<QuizQuestion> oldQuizQuestions = _quizRepository.GetQuizQuestions(quizId);
			List<int> oldQuizQuestionsIds = oldQuizQuestions.Select(qq => qq.QuestionId).ToList();
			// add new questions   -> added in update and not exist in db
			foreach (var questionId in quizViewModel.SelectedQuestionsIds)
			{
				if (!oldQuizQuestionsIds.Contains(questionId))
				{
					QuizQuestion quizQuestion = new QuizQuestion
					{
						QuizId = quizId,
						QuestionId = questionId
					};
					_quizRepository.AddQuizQuestion(quizQuestion);
				}
			}

			// delete old questions -> deleted in update and exist in db
			foreach (int oldQuestionId in oldQuizQuestionsIds)
			{
				if (!quizViewModel.SelectedQuestionsIds.Contains(oldQuestionId))
				{
					QuizQuestion quizQuestion = oldQuizQuestions.FirstOrDefault(qq => qq.QuestionId == oldQuestionId && qq.QuizId == quizId);
					_quizRepository.DeleteQuizQuestion(quizQuestion);
				}
			}
		}
	}
}
