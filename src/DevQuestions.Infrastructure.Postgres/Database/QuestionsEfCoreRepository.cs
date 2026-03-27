using DevQuestions.Application.Questions;
using DevQuestions.Domain.Questions;

using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Infrastructure.Postgres.Database;

public class QuestionsEfCoreRepository : IQuestionsRepository
{
	private readonly QuestionsDbContext _dbContext;

	public QuestionsEfCoreRepository(QuestionsDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Guid> AddAsync(Question question, CancellationToken cancellationToken)
	{
		_ = await _dbContext.Questions.AddAsync(question, cancellationToken);
		_ = await _dbContext.SaveChangesAsync(cancellationToken);

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
