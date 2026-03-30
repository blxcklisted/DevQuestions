using System.Text.Json;

using DevQuestions.Application.Exceptions;

using Shared;

namespace DevQuestions.Application.Questions.SystemErrors.Exceptions;

public class QuestionValidationException : BadRequestException
{
	public QuestionValidationException(Error[] errors)
		: base(errors)
	{
	}
}
