using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Hydra.Infrastructure.Configuration;
using Hydra.Infrastructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Hydra.Infrastructure.Repository
{
    public class MongoRepository : IRepository
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        /// <summary>
        /// This Contructor leverages  .NET Core built-in DI
        /// </summary>
        /// <param name="configOptions">Injected by .NET Core built-in Depedency Injection</param>
        public MongoRepository(ConfigurationOptions configOptions){
            _client = new MongoClient(configOptions.MongoConnection);
            _database = _client.GetDatabase(configOptions.MongoDatabaseName);
        }
        public void Add<T>(T item) where T : class, new() => GetCollection<T>().InsertOne(item);

        public void Add<T>(IEnumerable<T> items) where T : class, new() =>  GetCollection<T>().InsertMany(items);

        public IQueryable<T> All<T>() where T : class, new() => GetCollection<T>().AsQueryable();

        public bool CollectionExists<T>() where T : class, new()
        {
           var collection = GetCollection<T>();
           var filter = new BsonDocument();
           var totalCount = collection.CountDocuments(filter);
           return  totalCount > 0;
        }

        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class, new() => GetCollection<T>().DeleteMany(expression);

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class, new() => All<T>().Where(expression).SingleOrDefault();

        public IQueryable<T> Where<T>(Expression<Func<T, bool>> expression) where T : class, new() => All<T>().Where(expression);

        private IMongoCollection<T> GetCollection<T>() => _database.GetCollection<T>(typeof(T).Name);
    }
}