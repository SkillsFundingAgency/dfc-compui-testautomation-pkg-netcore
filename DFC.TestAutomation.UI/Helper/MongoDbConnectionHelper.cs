// <copyright file="MongoDbConnectionHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using MongoDB.Driver;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public class MongoDbConnectionHelper : IMongoDbConnectionHelper
    {
        public MongoDbConnectionHelper(Settings.MongoDatabaseSettings mongoDatabaseConfiguration)
        {
            var client = new MongoClient(mongoDatabaseConfiguration?.ConnectionString);
            this.Database = client.GetDatabase(mongoDatabaseConfiguration.DatabaseName);
        }

        private IMongoDatabase Database { get; set; }

        public async Task AsyncDeleteData<T>(string collectionName, FilterDefinition<T> filter)
        {
            await this.Database.GetCollection<T>(collectionName).DeleteOneAsync(filter).ConfigureAwait(false);
        }

        public async Task AsyncCreateData<T>(string collectionName, T[] data)
        {
            await this.Database.GetCollection<T>(collectionName).InsertManyAsync(data).ConfigureAwait(false);
        }
    }
}
