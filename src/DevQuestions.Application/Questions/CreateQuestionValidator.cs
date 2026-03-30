using DevQuestions.Contracts;
using FluentValidation;

namespace DevQuestions.Application.Questions;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionDto>
{
	public CreateQuestionValidator()
	{
		_ = RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title should not be empty").WithErrorCode("title_empty")
			.MaximumLength(500).WithMessage("Title is invalid");

		_ = RuleFor(x => x.Text)
			.NotEmpty().WithMessage("Text should not be empty").WithErrorCode("text_empty")
			.MaximumLength(5000).WithMessage("Text is invalid");

		_ = RuleFor(x => x.UserId)
			.NotEmpty().WithMessage("UserId should not be empty").WithErrorCode("user_id_empty");
	}
}
