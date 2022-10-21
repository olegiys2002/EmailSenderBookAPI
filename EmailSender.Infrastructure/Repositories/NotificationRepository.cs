using Core.IServices;
using Core.Models;
using EmailSender.Core.ExternalModels.OptionsModels;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories
{
    public class NotificationRepository : EntityRepository<Notification>,INotificationRepository
    {

        public NotificationRepository(IOptions<MongoDbConnectionSettings> mongoDbConnection) : base(mongoDbConnection)
        {

        }

    }
}
