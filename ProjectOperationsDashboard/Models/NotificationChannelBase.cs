using ProjectOperationsDashboard.Interfaces;

namespace ProjectOperationsDashboard.Models
{
    public abstract class NotificationChannelBase : INotificationChannel
    {
        // Requirement: Static Counter นับรวมทุก Channel
        public static int TotalSentAllChannels { get; protected set; }

        public abstract string ChannelName { get; }
        public int SentCount { get; protected set; }
        public List<string> Logs { get; } = new();

        public virtual void Send(NotificationMessage<string> msg)
        {
            SentCount++;
            TotalSentAllChannels++;
            Logs.Add($"[{DateTime.Now:HH:mm:ss}] {ChannelName} sent: {msg.Title}");
        }
    }
}