using DevQuestions.Domain.Questions;

using Microsoft.EntityFrameworkCore;

namespace DevQuestions.Infrastructure.Postgres;

public class QuestionsDbContext : DbContext
{
	public QuestionsDbContext(DbContextOptions<QuestionsDbContext> options)
		: base(options)
	{
	}

	public DbSet<Question> Questions { get; set; }
}
