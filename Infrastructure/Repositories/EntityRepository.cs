using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EntityRepository<T> : RepositoryBase<T> where T : Entity
    {
        public EntityRepository(AppDB appDB) : base(appDB)
        {
          
        }
        public async override Task Create(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _collection.InsertOneAsync(entity);
        }
    }
}
