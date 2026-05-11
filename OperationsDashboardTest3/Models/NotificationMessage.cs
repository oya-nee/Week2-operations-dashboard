namespace OperationsDashboardTest3.Models
{
    public class NotificationMessage<T> //รองรับทั้งข้อความแบบ string หรือข้อมูลแบบ object
    {
        public string Title { get; set; } = string.Empty; //เก็บชื่อหัวข้อของการแจ้งเตือน
        public T? Content { get; set; } //เก็บเนื้อหาจริงๆ ที่ส่ง
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}