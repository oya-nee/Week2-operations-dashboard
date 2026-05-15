using ProjectOperationsDashboard.Models;
using ProjectOperationsDashboard.Services;
using ProjectOperationsDashboard.Extensions;

//var service = new NotificationService();

//service.RegisterChannel(new EmailChannel());
//service.RegisterChannel(new SmsChannel());
//service.RegisterChannel(new DashboardAlertChannel());

////Enqueue และ HashSet (กันตัวซ้ำ)
//Console.WriteLine("Enqueuing");
//service.EnqueueMessage(new NotificationMessage<string> { Title = "[CRITICAL]Srver Down", Content = "Critical error" });
//service.EnqueueMessage(new NotificationMessage<string> { Title = "[INFO]Disk Full", Content = "Disk C is full" });
//service.EnqueueMessage(new NotificationMessage<string> { Title = "Server Down", Content = "Critical error" }); // ตัวนี้ต้องโดน Block

////Broadcast ส่งทุก Channel
//Console.WriteLine("\nTesting Broadcast");
//var msg = new NotificationMessage<string> { Title = "Test Broadcast", Content = "Hello" };
//service.Broadcast(msg);

//Console.WriteLine($"\nTotal Sent: {NotificationChannelBase.TotalSentAllChannels}");

Console.WriteLine("Project Operations Dashboard\n");

var priorityService = new PriorityNotificationService();

//priorityService.OnDashboardUpdate = (status) => Console.WriteLine($"[UI SIGNAL] {status}");

priorityService.RegisterChannel(new EmailChannel());
priorityService.RegisterChannel(new SmsChannel());
priorityService.RegisterChannel(new DashboardAlertChannel());

priorityService.EnqueueMessage(new NotificationMessage<string> { Title = "[INFO] Server check OK", Content = "All systems OK" });
priorityService.EnqueueMessage(new NotificationMessage<string> { Title = "[INFO] Server check OK", Content = "All systems OK" });//เอาไว้เช็คบ้อก
priorityService.EnqueueMessage(new NotificationMessage<string> { Title = "[CRITICAL] Srver Down", Content = "Srver Down" });
priorityService.EnqueueMessage(new NotificationMessage<string> { Title = "[CRITICAL] CPU Overheat", Content = "CPU Overheat" });
priorityService.EnqueueMessage(new NotificationMessage<string> { Title = "[CRITICAL] CPU Overheat", Content = "CPU Overheat" }); //เอาไว้เช็คบ้อก
priorityService.EnqueueMessage(new NotificationMessage<string> { Title = "[CRITICAL] CPU Overheat", Content = "CPU Overheat" });

Console.WriteLine("\nPriority Sorting");
priorityService.ProcessQueueWithPriority();

Console.WriteLine("\nSystem Report");
Console.WriteLine($"Global Total Sent (Static): {NotificationChannelBase.TotalSentAllChannels}");
Console.WriteLine($"Total Sent (Aggregate): {priorityService.GetTotalSentAllChannels()}"); 

Console.WriteLine("\nFlat Logs:"); // SelectMany
priorityService.GetAllFlatLogs().ForEach(log => Console.WriteLine(log));