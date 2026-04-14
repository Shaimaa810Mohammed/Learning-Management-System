using System.Reflection.Metadata.Ecma335;

namespace LearningManagementSystem.Utils
{
	public static class OTP
	{
		public static string GenerateOtp()
		{
			Random random = new Random();
			// Next(min, max) -> This generates a random number between two values:
		    // min = 100000 (included)
			// max = 999999 (NOT included)
			return random.Next(100000, 999999).ToString(); // Generates a 6-digit OTP
		}
		
	}
}
