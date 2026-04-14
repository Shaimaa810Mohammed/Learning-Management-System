using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.Services
{
	public class QuizSubmissionService : IQuizSubmissionService
	{
		private readonly IQuizSubmissionRepository _quizSubmissionRepository;
		private readonly IQuestionRepository _questionRepository;
		public QuizSubmissionService(IQuizSubmissionRepository quizSubmissionRepository, IQuestionRepository questionRepository)
		{
			_quizSubmissionRepository = quizSubmissionRepository;
			_questionRepository = questionRepository;
		}

		public void Add(SubmitQuizViewModel submitQuizViewModel)
		{
			int totalDegree = 0;
			for (int i = 0; i < submitQuizViewModel.StudentAnswers.Count; i++)
			{
				Question question = _questionRepository.GetById(submitQuizViewModel.QuestionsId[i]);
				if (question.CorrectAnswer == submitQuizViewModel.StudentAnswers[i])
				{
					totalDegree += question.MaxDegree;
				}
			}

			QuizSubmission quizSubmission = new QuizSubmission
			{
				QuizId = submitQuizViewModel.QuizId,
				ApplicationUserId = submitQuizViewModel.StudentId,
				Degree = totalDegree,
				StudentAnswers = submitQuizViewModel.StudentAnswers
			};

			_quizSubmissionRepository.Add(quizSubmission);
		}
	}
}
