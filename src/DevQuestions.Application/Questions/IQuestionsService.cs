using DevQuestions.Contracts;

namespace DevQuestions.Application.Questions;

public interface IQuestionsService
{
	Task<Guid> Create(CreateQuestionDto dto, CancellationToken cancellationToken);
}
