namespace GameShop.Models.Entity;

public class BaseNotification
{
    public long NotificationId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}