using System.Data;

using Dapper;

using DevQuestions.Application.Database;
using DevQuestions.Application.Questions;
using DevQuestions.Domain.Questions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Npgsql;

namespace DevQuestions.Infrastructure.Postgres.Database;

public class QuestionsDapperRepository : IQuestionsRepository
{
	private readonly ISqlConnectionFactory _sqlConnectionFactory;

	public QuestionsDapperRepository(ISqlConnectionFactory sqlConnectionFactory)
	{
		_sqlConnectionFactory = sqlConnectionFactory;
	}

	public async Task<Guid> AddAsync(Question question, CancellationToken cancellationToken)
	{
		const string sql = """
							INSERT INTO questions (id, title, text, user_id, screenshot_id, tags, status)
							VALUES (@Id, @Title, @Text, @UserId, @ScreenshotId, @Tags @Status) 
			""";

		using IDbConnection connection = _sqlConnectionFactory.Create();

		_ = await connection.ExecuteAsync(sql, new
		{
			question.Id,
			question.Title,
			question.Text,
			question.UserId,
			question.ScreenshotId,
			Tags = question.Tags.ToList(),
			question.Status,

		});

		return question.Id;
	}

	public Task<Guid> DeleteAsync(Guid questionId, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task<Question?> GetByIdAsync(Guid questionId, CancellationToken cancellationToken)
	{
		var question = await _dbContext
			.Questions
			.Include(x => x.Answers)
			.Include(x => x.Solution)
			.FirstOrDefaultAsync(x => x.Id == questionId, cancellationToken);

		return question;
	}

	public Task<int> GetOpenUserQuestionsAsync(Guid userId, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Guid> SaveAsync(Question question, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
