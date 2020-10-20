using Newtonsoft.Json;

namespace DFC.TestAutomation.UI.Model
{
    internal class BrowserStackTestStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
