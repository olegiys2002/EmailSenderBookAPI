using AutoMapper;
using Core.IServices;
using Core.Models;
using EmailSender.Core.DTO;

namespace Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NotificationService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<NotificationDTO> CreateNotification(NotificationDTO notificationDTO)
        {
            var notification = _mapper.Map<Notification>(notificationDTO);

            await _unitOfWork.NotificationRepository.Create(notification);

            return notificationDTO;
        }
        public async Task DeleteNotification(string id)
        {
            await _unitOfWork.NotificationRepository.Delete(id);
        }

        public async Task<List<NotificationDTO>> GetAllNotifications()
        {
           var notifications = await _unitOfWork.NotificationRepository.FindAllAsync();
           var notificationsDTOs = _mapper.Map<List<NotificationDTO>>(notifications);

           return notificationsDTOs;
        }

        public async Task<NotificationDTO> GetNotification(string id)
        {
            var notification= await _unitOfWork.NotificationRepository.FindByIdAsync(id);

            if (notification == null)
            {
                return null;
            }

            var notificationDTO = _mapper.Map<NotificationDTO>(notification);

            return notificationDTO;
        }
    }
}
