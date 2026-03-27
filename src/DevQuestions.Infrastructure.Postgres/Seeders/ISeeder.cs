namespace DevQuestions.Web.Seeders;

public interface ISeeder
{
	Task SeedAsync(CancellationToken cancellationToken);
}
