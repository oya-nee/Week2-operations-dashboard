using OperationsDashboardTest3.Interfaces;
using OperationsDashboardTest3.Models;

namespace OperationsDashboardTest3.Services
{
    public class NotificationService
    {
        //protected ใช้ได้ใน class นี้กะ class ลูก
        //readonly ห้ามเปลี่ยน object หลังสร้าง
        protected readonly Dictionary<string, INotificationChannel> _channels = new();
        protected Queue<NotificationMessage<string>> _messageQueue = new();
        protected readonly HashSet<string> _processedAlerts = new();

        //เอา channel ใหม่เข้ามาในระบบ
        public void RegisterChannel(INotificationChannel channel) => _channels[channel.ChannelName] = channel;

        public void EnqueueMessage(NotificationMessage<string> msg)
        {
            string alertKey = $"{msg.Title}_{msg.Timestamp:yyyyMMddHHmm}";
            if (_processedAlerts.Add(alertKey)) //ถ้ายังไม่เคยเจอ alert นี้ ก้ enqueue
            {
                _messageQueue.Enqueue(msg);
                Console.WriteLine($"Enqueued: {msg.Title}");
            }
            else
            {
                Console.WriteLine($"Duplicate Alert blocked: {msg.Title}");
            }
        }

        public virtual void Broadcast(NotificationMessage<string> msg) //ส่งข้อความไปทุก Channel
        {
            // ลูก override ได้
            foreach (var channel in _channels.Values)
            {
                channel.Send(msg);
            }
        }
    }
}