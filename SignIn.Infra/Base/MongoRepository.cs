using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using SignIn.Domain.Base;
using SignIn.Domain.Models;
using SignIn.Infra.Interfaces;

namespace SignIn.Infra.Base
{
    public abstract class MongoRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;
        protected MongoRepository(MongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public async Task<T> GetById(string id)
        {
            return await _collection.Find( el => el.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
            => await _collection.Find(_ => true).ToListAsync();
        

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                await _collection.ReplaceOneAsync(el => el.Id == entity.Id, entity);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task Delete(string id)
        {
            await _collection.DeleteOneAsync(el => el.Id == id);
        }
    }
}