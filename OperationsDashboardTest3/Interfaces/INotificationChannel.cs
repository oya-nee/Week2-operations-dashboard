using OperationsDashboardTest3.Models;

namespace OperationsDashboardTest3.Interfaces
{
    public interface INotificationChannel
    {
        string ChannelName { get; } //เช่น "Email", "SMS"
        int SentCount { get; } //นับว่าส่งไปแล้วกี่ครั้ง
        List<string> Logs { get; } //(List) เก็บประวัติการส่งเป็นตัวอักษร

        //ทุกช่องทางต้องมีปุ่มMethod Send โดยต้องรับ NotificationMessage เข้าไปประมวลผลด้วย
        void Send(NotificationMessage<string> msg);
    }
}