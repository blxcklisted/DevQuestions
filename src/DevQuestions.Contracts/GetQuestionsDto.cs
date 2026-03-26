namespace DevQuestions.Contracts;

public record GetQuestionsDto(string Search, Guid[] TagIds, int page, int pageSize);
