using ProjectOperationsDashboard.Models;

namespace ProjectOperationsDashboard.Services
{
    public class PriorityNotificationService : NotificationService
    {
        public Action<string>? OnDashboardUpdate;

        public override void Broadcast(NotificationMessage<string> msg)
        {
            if (msg.Title.Contains("[CRITICAL]"))
            {
                foreach (var channel in _channels.Values) channel.Send(msg);
            }
            else if (msg.Title.Contains("[WARNING]"))
            {
                var targets = _channels.Values.Where(c => c.ChannelName != "Dashboard");
                foreach (var c in targets) c.Send(msg);
            }
            else // infoo 
            {
                var dashboard = _channels.Values.FirstOrDefault(c => c.ChannelName == "Dashboard");
                dashboard?.Send(msg);
            }
        }

        public void ProcessQueue()
        {
            var sortedMessages = _messageQueue.OrderBy(m => m.Timestamp).ToList(); // เรียงลำดับามเวลา
            _messageQueue.Clear(); //ล้างคิวเดิมออก

            foreach (var msg in sortedMessages)
            {
                Broadcast(msg);
                OnDashboardUpdate?.Invoke($"Processed {msg.Title} successfully.");
            }
        }

        //Priority Sorting
        public int GetTotalSentAllChannels()
        {
            return _channels.Values.Sum(channel => channel.SentCount);
        }

        public List<string> GetAllFlatLogs()
        {
            return _channels.Values.SelectMany(channel => channel.Logs).ToList();
        }

        public void ProcessQueueWithPriority()
        {
            var messages = _messageQueue.ToList();   //ก้อปออกมาเป็น ลิส 
            messages.Sort(new Helpers.AlertPriorityComparer());
            _messageQueue.Clear();

            foreach (var msg in messages)
            {
                Broadcast(msg);
                OnDashboardUpdate?.Invoke($"Processed {msg.Title} with Priority.");
            }
        }

    }
}
 