using MongoDB.Driver;
using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IMongoDbConnectionHelper
    {
        Task AsyncDeleteData<T>(string collectionName, FilterDefinition<T> filter);

        Task AsyncCreateData<T>(string collectionName, T[] data);
    }
}
