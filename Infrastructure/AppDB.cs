using Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDB 
    {
        private MongoClient _mongoClient;
        public IMongoDatabase NotificationDatabase { get; set; }
        public AppDB()
        {
            _mongoClient = new MongoClient(connectionString: "mongodb://emailsender-db:27017");
            NotificationDatabase = _mongoClient.GetDatabase("notification");
        }
        public IMongoCollection<Notification> GetNotificationCollection()
        {
            return NotificationDatabase.GetCollection<Notification>("Notifications");
        }
    }
}
