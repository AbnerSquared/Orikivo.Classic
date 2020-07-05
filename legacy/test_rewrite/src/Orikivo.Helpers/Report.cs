using System;

namespace Orikivo.Helpers
{
    public class Report
    {
        public ulong Id { get; } // the report case id.
        public Author Author { get; } // the user that posted this report.
        public CompactCommandInfo Command { get; } // the command that was used to report.
        public OriReportPriorityType Priority { get; } // the priority of the report.
        public string Subject { get; } // the subject of the report.
        public string Summary { get; } // the summary of the report.
        public DateTime CreatedAt { get; } // the time the report was created.
        public DateTime? EditedAt { get; } // the time the report was edited, if any.
        public ReportStatusType Status { get; } // the status of the project.
    }
}
