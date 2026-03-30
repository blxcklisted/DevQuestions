using Shared;

namespace DevQuestions.Application.Questions.SystemErrors;

public partial class Errors
{
	public static class Questions
	{
		public static Error TooManyQuestions() =>
			Error.Failure(
				"questions_too_many",
				"User cannot add more than 3 questions");
	}
}
