using FluentValidation.Results;

using Shared;

namespace DevQuestions.Application.Extensions;

public static class ValidationExtensions
{
	public static Error[] ToErrors(this ValidationResult result)
		=> result.Errors.Select(x => Error.Validation(
			x.ErrorCode, x.ErrorMessage, x.PropertyName)).ToArray();
}
