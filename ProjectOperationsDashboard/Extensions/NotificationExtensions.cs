using ProjectOperationsDashboard.Interfaces;

namespace ProjectOperationsDashboard.Extensions
{
    public static class NotificationExtensions
    {
        public static IEnumerable<INotificationChannel> WhereNotThrottled(this IEnumerable<INotificationChannel> channels, int maxLimit)
        {
            return channels.Where(c => c.SentCount < maxLimit);
        }
    }
}
