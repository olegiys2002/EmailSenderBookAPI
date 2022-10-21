using Core.Models;
using EmailSender.Core.ExternalModels.OptionsModels;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace Infrastructure.Repositories
{
    public class EntityRepository<T> : RepositoryBase<T> where T : Entity
    {
        public EntityRepository(IOptions<MongoDbConnectionSettings> mongoDbConnection) : base(mongoDbConnection)
        {
          
        }
        public override Task Create(T entity)
        {
         
            entity.CreatedAt = DateTime.Now;
            return _collection.InsertOneAsync(entity);
        }
    }
}
