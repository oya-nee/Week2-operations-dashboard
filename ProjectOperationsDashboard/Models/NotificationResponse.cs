namespace ProjectOperationsDashboard.Models
{
    public class NotificationResponse<T>
    {
        public bool IsSuccess { get; set; }
        public DateTime TimeSent { get; set; }
        public string? ErrorMessage { get; set; }
        public T? OriginalContent { get; set; }
    }
}
