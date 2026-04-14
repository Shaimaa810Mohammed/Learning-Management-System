using LearningManagementSystem.Models;
using LearningManagementSystem.RepositoryContracts;
using LearningManagementSystem.ServiceContracts;

namespace LearningManagementSystem.Services
{
	public class MediaService : IMediaService
	{
		private readonly IMediaRepository _mediaRepository;
		public MediaService(IMediaRepository mediaRepository)
		{
			_mediaRepository = mediaRepository;
		}

		public void Add(IFormFile file, int lessonId)
		{
			 // create unique file name using guid
			string uniqueFileName = Guid.NewGuid().ToString() + file.FileName;
			string relativePath = Path.Combine("MediaFiles", uniqueFileName);
			string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);
			// save file
			using (var stream = new FileStream(absolutePath, FileMode.Create))
			{
				file.CopyTo(stream);
			}
			Media media = new Media() { FilePath = relativePath, FileName = file.FileName, LessonId = lessonId };
			if (file.ContentType.ToLower().StartsWith("video"))
			{
				media.MediaType = "video";
			}
			else if (file.ContentType.ToLower().StartsWith("audio"))
			{
				media.MediaType = "audio";
			}
			else
			{
				media.MediaType = "file";
			}
			_mediaRepository.Add(media);
		}

		public void Delete(int mediaId)
		{
			Media? media = _mediaRepository.GetById(mediaId);
			string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", media.FilePath);
			// Delete file from wwwroot
			if (File.Exists(fullPath))
			{
				File.Delete(fullPath);
			}
			_mediaRepository.Delete(media);
		}

		public Media GetById(int id)
		{
			return _mediaRepository.GetById(id);
		}
	}
}
