using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IHttpClientRequestHelper
    {
        Task<string> ExecuteHttpPostRequest(string requestUri, string postData);

        Task<string> ExecuteHttpGetRequest(string requestUri);

        Task<string> ExecuteHttpPutRequest(string requestUri, string putData);

        Task ExecuteHttpDeleteRequest(string requestUri, string deleteData);

        Task<string> ExecuteHttpPatchRequest(string requestUri, string patchData);
    }
}
