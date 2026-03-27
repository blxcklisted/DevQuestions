namespace DevQuestions.Web.Seeders;

public static class SeederExtension
{
	public static async Task<WebApplication> UseSeeders(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();
		var seeders = scope.ServiceProvider.GetServices<ISeeder>();
		foreach (var seeder in seeders)
		{
			seeder.SeedAsync(CancellationToken.None).GetAwaiter().GetResult();
		}

		return app;
	}
}
