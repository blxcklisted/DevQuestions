using DevQuestions.Web.Seeders;

using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Infrastructure.Postgres.Seeders;

public class QuestionsSeeder : ISeeder
{
	private readonly DbContext _dbContext;

	public QuestionsSeeder(DbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task SeedAsync(CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
