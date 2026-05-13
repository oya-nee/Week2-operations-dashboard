namespace OperationsDashboardTest3.Models
{
    public class EmailChannel : NotificationChannelBase
    {
        public override string ChannelName => "Email";
        public override void Send(NotificationMessage<string> msg)
        {
            base.Send(msg);
            Console.WriteLine($"[Email] Sending to DEV Team: {msg.Content}");
        }
    }
}