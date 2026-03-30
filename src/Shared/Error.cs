using System.Text.Json.Serialization;

namespace Shared;

public record Error
{
	public string Code { get; set; }
	public string Message { get; set; }
	public ErrorType Type { get; set; }
	public string? InvalidField { get; set; }

	[JsonConstructor]
	private Error(string code, string message, ErrorType type, string? invalidField = null)
	{
		Code = code;
		Message = message;
		Type = type;
		InvalidField = invalidField;
	}

	public static Error NotFound(string? code, string message, Guid? id)
		=> new (code ?? "record_not_found", message, ErrorType.NOT_FOUND);
	public static Error Validation(string? code, string message, string invalidField)
		=> new (code ?? "validation_error", message, ErrorType.VALIDATION, invalidField);

	public static Error Conflict(string? code, string message)
		=> new (code ?? "conflict", message, ErrorType.CONFLICT);
	public static Error Failure(string? code, string message)
		=> new (code ?? "failure", message, ErrorType.FAILURE);
}

public enum ErrorType
{
	/// <summary>
	/// Validation error
	/// </summary>
	VALIDATION,

	/// <summary>
	/// Not found error
	/// </summary>
	NOT_FOUND,

	/// <summary>
	/// Server error
	/// </summary>
	FAILURE,

	/// <summary>
	/// Error conflict
	/// </summary>
	CONFLICT,
}
