using DevQuestions.Application.Questions;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace DevQuestions.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		_ = services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

		_ = services.AddScoped<IQuestionsService, QuestionsService>();

		return services;
	}
}
