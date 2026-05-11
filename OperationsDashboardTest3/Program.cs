using OperationsDashboardTest3.Models;
using OperationsDashboardTest3.Services;

var service = new NotificationService();

service.RegisterChannel(new EmailChannel());
service.RegisterChannel(new SmsChannel());
service.RegisterChannel(new DashboardAlertChannel());

//Enqueue และ HashSet (กันตัวซ้ำ)
Console.WriteLine("Enqueuing");
service.EnqueueMessage(new NotificationMessage<string> { Title = "Server Down", Content = "Critical error" });
service.EnqueueMessage(new NotificationMessage<string> { Title = "Disk Full", Content = "Disk C is full" });
service.EnqueueMessage(new NotificationMessage<string> { Title = "Server Down", Content = "Critical error" }); // ตัวนี้ต้องโดน Block

//Broadcast ส่งทุก Channel
Console.WriteLine("\nTesting Broadcast");
var msg = new NotificationMessage<string> { Title = "Test Broadcast", Content = "Week2 Day 1" };
service.Broadcast(msg);

Console.WriteLine($"\nTotal Sent: {NotificationChannelBase.TotalSentAllChannels}");