using DevQuestions.Application.Exceptions;

using Shared;

namespace DevQuestions.Application.Questions.SystemErrors.Exceptions;

public class QuestionNotFoundException : NotFoundException
{
	protected QuestionNotFoundException(Error[] errors)
		: base(errors)
	{
	}
}
