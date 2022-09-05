using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IServices
{
    public interface INotificationService
    {
        Task CreateNotification(Notification notification);
        public Notification GetNotification(string message);
    }
}
