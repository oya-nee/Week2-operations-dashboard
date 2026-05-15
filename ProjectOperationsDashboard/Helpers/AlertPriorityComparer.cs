using ProjectOperationsDashboard.Models;

namespace ProjectOperationsDashboard.Helpers
{
    public class AlertPriorityComparer : IComparer<NotificationMessage<string>>
    {
        public int Compare(NotificationMessage<string>? x, NotificationMessage<string>? y)
        {
            if (x == null || y == null) return 0;
            return GetSeverityLevel(x.Title).CompareTo(GetSeverityLevel(y.Title));
        }

        private int GetSeverityLevel(string title)
        {
            if (title.Contains("[CRITICAL]")) return 1;
            if (title.Contains("[WARNING]")) return 2;
            return 3;
        }
    }
}
