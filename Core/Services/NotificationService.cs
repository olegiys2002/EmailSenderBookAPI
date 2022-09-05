using Core.IServices;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task CreateNotification(Notification notification)
        {
           await _unitOfWork.NotificationRepository.Create(notification);
        }
        public Notification GetNotification(string message)
        {
            Notification notification = new Notification()
            {
                Id = null,
                Message = message
            };
            return notification;
        }
    }
}
