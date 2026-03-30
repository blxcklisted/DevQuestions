using DevQuestions.Application;
using DevQuestions.Web;
using DevQuestions.Web.Middlewares;
using DevQuestions.Web.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddProgramDependencies();

var app = builder.Build();

app.UseExceptionMiddleware();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "DevQuestions"));
}

app.MapControllers();

using var scope = app.Services.CreateScope();

app.UseSeeders();

app.Run();
