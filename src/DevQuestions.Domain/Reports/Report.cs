namespace DevQuestions.Domain.Reports;

public class Report
{
	public Guid Id { get; set; }

	public required Guid UserId { get; set; }

	public required Guid ReportedUserId { get; set; }

	public Guid? ResolvedByUserId { get; set; }

	public required string Reason { get; set; }

	public Guid? ScreenshotId { get; set; }

	public ReportStatus Status { get; set; } = ReportStatus.OPEN;

	public DateTime CreatedOn { get; set; }

	public DateTime? UpdatedOn { get; set; }
}
