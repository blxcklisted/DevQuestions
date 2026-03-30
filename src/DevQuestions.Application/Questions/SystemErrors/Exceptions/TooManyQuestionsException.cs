using Shared;

namespace DevQuestions.Application.Questions.SystemErrors.Exceptions;

public class TooManyQuestionsException : QuestionValidationException
{
	public TooManyQuestionsException()
		: base([Errors.Questions.TooManyQuestions()])
	{
	}
}
