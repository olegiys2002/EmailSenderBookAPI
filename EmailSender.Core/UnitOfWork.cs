using Core.IServices;
using EmailSender.Core.ExternalModels.OptionsModels;
using Infrastructure.Repositories;
using Microsoft.Extensions.Options;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOptions<MongoDbConnectionSettings> _mongoDbConnection;
        private INotificationRepository _notificationRepository;
        public UnitOfWork(IOptions<MongoDbConnectionSettings> mongoDbConnection)
        {
            _mongoDbConnection = mongoDbConnection;
        }
        public INotificationRepository NotificationRepository
        {
            get
            {
                _notificationRepository ??= new NotificationRepository(_mongoDbConnection);
                return _notificationRepository;
            }
        }
    }
}
