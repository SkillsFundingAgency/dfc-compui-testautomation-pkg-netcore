using DFC.TestAutomation.UI.Config;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public class MongoDbConnectionHelper : IMongoDbConnectionHelper
    {
        private IMongoDatabase Database { get; set; }

        public MongoDbConnectionHelper(MongoDatabaseConfiguration mongoDatabaseConfiguration)
        {
            var client = new MongoClient(mongoDatabaseConfiguration.Uri);
            this.Database = client.GetDatabase(mongoDatabaseConfiguration.Database);
        }

        public async Task AsyncDeleteData<T>(string collectionName, FilterDefinition<T> filter)
        {
            await this.Database.GetCollection<T>(collectionName).DeleteOneAsync(filter);
        }

        public async Task AsyncCreateData<T>(string collectionName, T[] data)
        {
            await this.Database.GetCollection<T>(collectionName).InsertManyAsync(data);
        }
    }
}
