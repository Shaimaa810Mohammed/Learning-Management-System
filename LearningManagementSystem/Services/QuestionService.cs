using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.Services
{
	public class QuestionService : IQuestionService
	{
		private readonly IQuestionRepository _questionRepository;
		public QuestionService(IQuestionRepository questionRepository)
		{
			_questionRepository = questionRepository;
		}

		public void Add(QuestionViewModel questionViewModel)
		{
			Question question = new Question()
			{
				QuestionText = questionViewModel.QuestionText,
				QuestionType = questionViewModel.QuestionType,
				MaxDegree = questionViewModel.MaxDegree,
				CourseId = questionViewModel.CourseId,
				AnswerOptions = questionViewModel.AnswerOptions,
				CorrectAnswer = questionViewModel.CorrectAnswer,
			};

			_questionRepository.Add(question);
		}

		public void Delete(int questionId)
		{
			Question question = _questionRepository.GetById(questionId);
			_questionRepository.Delete(question);
		}

		public Question? GetById(int id)
		{
			return _questionRepository.GetById(id);
		}

		public List<Question> GetCourseQuestions(int courseId)
		{
			return _questionRepository.GetCourseQuestions(courseId);
		}

		public void Update(QuestionViewModel questionViewModel, int questionId)
		{
			Question question = _questionRepository.GetById(questionId);
			question.QuestionText = questionViewModel.QuestionText;
			question.QuestionType = questionViewModel.QuestionType;
			question.MaxDegree = questionViewModel.MaxDegree;
			question.AnswerOptions = questionViewModel.AnswerOptions;
			question.CorrectAnswer = questionViewModel.CorrectAnswer;
			question.CourseId = questionViewModel.CourseId;
			_questionRepository.Update(question);
		}
	}
}
