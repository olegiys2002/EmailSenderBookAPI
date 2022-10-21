using Core.Models;
using EmailSender.Core.ExternalModels.OptionsModels;
using EmailSender.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected  IMongoCollection<T> _collection;
        public RepositoryBase(IOptions<MongoDbConnectionSettings> mongoDbConnection)
        {
            var settings = mongoDbConnection.Value;
            var mongoDatabase = new MongoClient(connectionString: settings.ConnectionURI).GetDatabase(settings.DatabaseName);
            _collection = mongoDatabase.GetCollection<T>(GetCollectionName(typeof(T))) ;
        }
        public string GetCollectionName(Type connectionType)
        {
            return connectionType.Name;
        }
        public virtual Task<List<T>> FindAllAsync()
        {
            return _collection.AsQueryable().ToListAsync();
        }
        public virtual Task Create(T entity)
        {
           return _collection.InsertOneAsync(entity);
        }
        public virtual Task<T> FindByIdAsync(string id)
        {
            return _collection.Find(entity => entity.Id == id).FirstOrDefaultAsync();
        }
        public virtual Task Delete(string id)
        {
            return _collection.DeleteOneAsync(entity => entity.Id == id );
        }
        
    }
}
