using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using LearningManagementSystem.ServiceContracts;
using LearningManagementSystem.Utils;
using LearningManagementSystem.ViewModels;

namespace LearningManagementSystem.Services
{
	public class LessonService : ILessonService
	{
		private readonly ILessonRepository _lessonRepository;
		public LessonService(ILessonRepository lessonRepository)
		{
			_lessonRepository = lessonRepository;
		}

		public void Add(CreateLessonViewModel lessonViewModel)
		{
			// save media files in -> wwwroot/MediaFiles
			// create MediaFiles folder if not exists
			string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "MediaFiles");
			// check if folder exists or not
			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}

			// save media files in MediaFiles folder
			List<Media> medias = new List<Media>();

			foreach (var mediaFile in lessonViewModel.MediaFiles)
			{
				// create unique file name using guid
				string uniqueFileName = Guid.NewGuid().ToString() + mediaFile.FileName;
				string relativePath = Path.Combine("MediaFiles", uniqueFileName);
				string absolutePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", relativePath);
				// save file
				using (var stream = new FileStream(absolutePath, FileMode.Create))
				{
					mediaFile.CopyTo(stream);
				}
				Media media = new Media() { FilePath = relativePath, FileName = mediaFile.FileName };
				if (mediaFile.ContentType.ToLower().StartsWith("video"))
				{
					media.MediaType = "video";
				}
				else if (mediaFile.ContentType.ToLower().StartsWith("audio"))
				{
					media.MediaType = "audio";
				}
				else
				{
					media.MediaType = "file";
				}
				medias.Add(media);
			}

			Lesson lesson = new Lesson() 
			{ 
				Title = lessonViewModel.Title, 
				MediaFiles = medias, 
				CourseId = lessonViewModel.CourseId, 
				OTP = OTP.GenerateOtp(),
			};
			_lessonRepository.Add(lesson);
		}

		public void Delete(int id)
		{
			Lesson lesson = GetById(id);
			foreach (var file in lesson.MediaFiles)
			{
				string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FilePath);
				// Delete file from wwwroot
				if (File.Exists(fullPath))
				{
					File.Delete(fullPath);
				}
			}
			_lessonRepository.Delete(lesson);
		}

		public Lesson? GetById(int id)
		{
			return _lessonRepository.GetById(id);
		}

		public void Update(UpdateLessonViewModel lessonViewModel)
		{
			Lesson oldLesson = GetById(lessonViewModel.LessonId);
			oldLesson.Title = lessonViewModel.Title;
			_lessonRepository.Update(oldLesson);
		}
	}
}
