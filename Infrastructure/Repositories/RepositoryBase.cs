using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.IServices;
using EmailSender.Services;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        protected  AppDB _appDB;
        protected  IMongoCollection<T> _collection;
        public RepositoryBase(AppDB appDB)
        {
            _appDB = appDB;
            _collection = _appDB.NotificationDatabase.GetCollection<T>("Notifications") ;
        }
        public virtual async Task Create(T entity)
        {
           await _collection.InsertOneAsync(entity);
        }

        
    }
}
