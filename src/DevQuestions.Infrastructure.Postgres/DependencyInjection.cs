using DevQuestions.Application;
using DevQuestions.Application.Database;
using DevQuestions.Application.Questions;
using DevQuestions.Infrastructure.Postgres.Database;

using Microsoft.Extensions.DependencyInjection;

namespace DevQuestions.Infrastructure.Postgres;

public static class DependencyInjection
{
	public static IServiceCollection AddPostgresInfrastructure(this IServiceCollection services)
	{
		_ = services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
		_ = services.AddScoped<IQuestionsRepository, QuestionsDapperRepository>();
		_ = services.AddScoped<IQuestionsRepository, QuestionsEfCoreRepository>();

		return services;
	}

}
