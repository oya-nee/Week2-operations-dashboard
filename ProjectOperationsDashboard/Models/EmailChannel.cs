//namespace ProjectOperationsDashboard.Models
//{
//    public class EmailChannel : NotificationChannelBase
//    {
//        public override string ChannelName => "Email";
//        public override void Send(NotificationMessage<string> msg)
//        {
//            base.Send(msg);
//            Console.WriteLine($"[Email] Sending to DEV Team: {msg.Content}");
//        }
//    }
//}

using System.Net.Mail;

//namespace ProjectOperationsDashboard.Models
//{
//    public class EmailChannel : NotificationChannelBase
//    {
//        public override string ChannelName => "Email";

//        private readonly Lazy<SmtpClient> _smtpClient = new Lazy<SmtpClient>(() =>
//        {
//            Console.WriteLine("[System] Initializing SMTP Connection.");
//            return new SmtpClient("smtp.pranworks.internal");
//        });

//        public override void Send(NotificationMessage<string> msg)
//        {
//            base.Send(msg);
//            var client = _smtpClient.Value;
//            Console.WriteLine($"[Email] Sent via {client.Host}: {msg.Content}");
//        }
//    }
//}

namespace ProjectOperationsDashboard.Models
{
    public class EmailChannel : NotificationChannelBase
    {
        public override string ChannelName => "Email";

        private readonly SmtpClient _smtpClient = new SmtpClient("smtp.pranworks.internal");

        public override void Send(NotificationMessage<string> msg)
        {
            base.Send(msg);
            Console.WriteLine($"[Email] Sent via {_smtpClient.Host}: {msg.Content}");
        }
    }
}

