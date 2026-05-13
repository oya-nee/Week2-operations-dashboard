namespace OperationsDashboardTest3.Models
{
    public class DashboardAlertChannel : NotificationChannelBase
    {
        public override string ChannelName => "Dashboard";
        public override void Send(NotificationMessage<string> msg)
        {
            base.Send(msg);
            Console.WriteLine($"[Dashboard] Alert Appears: {msg.Title}");
        }
    }
}