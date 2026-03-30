using DevQuestions.Application.Questions;
using DevQuestions.Contracts;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevQuestions.Presenters.Questions;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
	private readonly IQuestionsService _questionsService;

	public QuestionsController(IQuestionsService questionsService)
	{
		_questionsService = questionsService;
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateQuestionDto request, CancellationToken cancellationToken)
	{
		try
		{
			Guid id = await _questionsService.Create(request, cancellationToken);
			return Ok(id);
		}
		catch
		{
			throw;
		}
	}

	[HttpGet]
	public async Task<IActionResult> Get([FromQuery] GetQuestionsDto request, CancellationToken cancellationToken)
	{
		return Ok("Questions retrieved");
	}

	[HttpGet("{questionId:guid}")]
	public async Task<IActionResult> GetById([FromRoute] Guid questionId, CancellationToken cancellationToken)
	{
		return Ok("Questions retrieved");
	}

	[HttpGet("{questionId:guid}")]
	public async Task<IActionResult> Update([FromRoute] Guid questionId, [FromBody] UpdateQuestionDto request, CancellationToken cancellationToken)
	{
		return Ok("Questions updated");
	}

	[HttpDelete("{questionId:guid}")]
	public async Task<IActionResult> Delete([FromRoute] Guid questionId, CancellationToken cancellationToken)
	{
		return Ok("Questions deleted");
	}

	[HttpPut("{questionId:guid}/solution")]
	public async Task<IActionResult> SelectSolution([FromRoute] Guid questionId, [FromQuery] Guid answerId, CancellationToken cancellationToken)
	{
		return Ok("Answer marked as correct");
	}

	[HttpPost("{questionId:guid}/answers")]
	public async Task<IActionResult> AddAnswer([FromRoute] Guid questionId, [FromBody] AddAnswerDto request, CancellationToken cancellationToken)
	{
		return Ok("Answer added");
	}
}
