using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystem.Constraint
{
	public class CompareWithStartTimeAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			DateTime? endTime = (DateTime?)value;
			if (endTime != null)
			{
				var model = validationContext.ObjectInstance;
				var prop = validationContext.ObjectType.GetProperty("StartTime");
				DateTime? startTime = (DateTime?)prop?.GetValue(model);
				if (startTime != null && endTime > startTime)
				{
					return ValidationResult.Success;
				}
			}
			return new ValidationResult("End Time must be greater than Start Time");
		}
	}
}
