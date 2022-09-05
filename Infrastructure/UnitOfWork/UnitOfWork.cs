using Core.IServices;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDB _appDB;
        private INotificationRepository _notificationRepository;
        public UnitOfWork(AppDB appDB)
        {
            _appDB = appDB;
        }
        public INotificationRepository NotificationRepository
        {
            get
            {
                _notificationRepository ??= new NotificationRepository(_appDB);
                return _notificationRepository;
            }
        }
    }
}
