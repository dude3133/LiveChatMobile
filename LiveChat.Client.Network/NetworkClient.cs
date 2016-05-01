using LiveChat.Client.Network.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LiveChat.Client.Network
{
    public class NetworkClient : INetworkClient
    {
        public NetworkClient()
        {
            httpClient = new HttpClient();
        }

        private HttpClient httpClient;

        public Task<T> GetRequst<T>(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<T> PostRequst<T>(string url, object content)
        {
            T result = default(T);
            var body = JsonConvert.SerializeObject(content);
            try
            {
                var response = await httpClient.PostAsync(url, new StringContent(body, Encoding.UTF8,
                   "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(responseString);
                }
            }
            catch (Exception ex)
            {
                var x = 2;
            }
            return result;
        }

        public async Task<string> Token(string url, string username, string password)
        {
            TokenReturnModel result = null;
            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(url,
                   new StringContent(string.Format("grant_type=password&username={0}&password={1}",
                   username, password), Encoding.UTF8,
                   "application/x-www-form-urlencoded"));

                if (!response.IsSuccessStatusCode) return "";

                string resultJSON = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TokenReturnModel>(resultJSON);
            }
            catch (Exception ex)
            {
                var x = 2;
            }
            return result.AccessToken;
        }

    }
}
