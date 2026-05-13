namespace OperationsDashboardTest3.Models
{
    public class SmsChannel : NotificationChannelBase
    {
        public override string ChannelName => "SMS";
        public override void Send(NotificationMessage<string> msg)
        {
            base.Send(msg);
            Console.WriteLine($"[SMS] Sending to On-call Leader: {msg.Content}");
        }
    }

}