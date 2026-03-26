using DevQuestions.Contracts;
using FluentValidation;

namespace DevQuestions.Application.Questions;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionDto>
{
	public CreateQuestionValidator()
	{
		_ = RuleFor(x => x.Title)
			.NotEmpty()
			.MaximumLength(500)
			.WithMessage("Title is invalid");

		_ = RuleFor(x => x.Text)
			.NotEmpty()
			.MaximumLength(5000)
			.WithMessage("Text is invalid");

		_ = RuleFor(x => x.UserId)
			.NotEmpty();
	}
}
