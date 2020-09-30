using System.Threading.Tasks;

namespace DFC.TestAutomation.UI.Helper
{
    public interface IHttpClientRequestHelper
    {
        Task<string> ExecuteHttpPostRequest(string postData);

        Task<string> ExecuteHttpGetRequest();

        Task<string> ExecuteHttpPutRequest(string putData);

        Task ExecuteHttpDeleteRequest(string deleteData);

        Task<string> ExecuteHttpPatchRequest(string patchData);
    }
}
