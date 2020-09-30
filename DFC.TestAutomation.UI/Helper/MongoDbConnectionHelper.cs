﻿using DFC.TestAutomation.UI.Config;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public class MongoDbConnectionHelper
    {
        private readonly MongoDatabaseConfiguration _config;

        public MongoDbConnectionHelper(MongoDatabaseConfiguration config)
        {
            _config = config;
        }

        public async Task AsyncDeleteData<T>(string collectionName, FilterDefinition<T> filter)
        {
            await GetCollection<T>(collectionName).DeleteOneAsync(filter);
        }

        public async Task AsyncCreateData<T>(string collectionName, T[] data)
        {
            await GetCollection<T>(collectionName).InsertManyAsync(data);
        }

        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            var db = GetMongoDatabase();
            return db.GetCollection<T>(collectionName);
        }
        private IMongoDatabase GetMongoDatabase()
        {
            var client = new MongoClient(_config.Uri);
            return client.GetDatabase(_config.Database);
        }
    }
}