using DevQuestions.Contracts;
using DevQuestions.Domain.Questions;

using FluentValidation;
using FluentValidation.Results;

using Microsoft.Extensions.Logging;

namespace DevQuestions.Application.Questions;

public class QuestionsService : IQuestionsService
{
	private readonly IQuestionsRepository _repository;
	private readonly ILogger<QuestionsService> _logger;
	private readonly IValidator<CreateQuestionDto> _validator;

	public QuestionsService(
		IQuestionsRepository repository,
		ILogger<QuestionsService> logger,
		IValidator<CreateQuestionDto> validator)
	{
		_repository = repository;
		_logger = logger;
		_validator = validator;
	}

	public async Task<Guid> Create(CreateQuestionDto dto, CancellationToken cancellationToken)
	{
		ValidationResult validationResult = await _validator.ValidateAsync(dto, cancellationToken);
		if (!validationResult.IsValid)
		{
			throw new ValidationException(validationResult.Errors);
		}

		var openUserQuestionsCount = await _repository.GetOpenUserQuestionsAsync(dto.UserId, cancellationToken);
		if (openUserQuestionsCount > 3)
		{
			throw new Exception("User cannot have more than 3 open questions.");
		}

		var questionId = Guid.NewGuid();
		var question = new Question(
			questionId,
			dto.Title,
			dto.Text,
			dto.UserId,
			null,
			dto.TagIds);

		_ = await _repository.AddAsync(question, cancellationToken);
		_logger.LogInformation("Question created with ID: {QuestionId}", questionId);

		return questionId;
	}
}
