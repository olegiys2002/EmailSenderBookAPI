using Core.Models;
using EmailSender.Core.DTO;

namespace Core.IServices
{
    public interface INotificationService
    {
        Task<NotificationDTO> CreateNotification(NotificationDTO notification);
        Task DeleteNotification(string id);
        Task<NotificationDTO> GetNotification(string id);
        Task<List<NotificationDTO>> GetAllNotifications();
    }
}
