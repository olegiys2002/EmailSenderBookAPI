using Core.IServices;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NotificationRepository : EntityRepository<Notification>,INotificationRepository
    {

        public NotificationRepository(AppDB appDB) : base(appDB)
        {

        }

    }
}
