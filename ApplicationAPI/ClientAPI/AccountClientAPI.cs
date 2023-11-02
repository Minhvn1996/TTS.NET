using NetAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ApplicationAPI.ClientAPI
{
    public class AccountClientAPI
    {
        private HttpClient _client;

        public AccountClientAPI()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:5000/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AccountViewModel> Login(LoginRequest request)
        {
            string apiUrl = "/api/accounts/login";
            string jsonString = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                AccountViewModel account = JsonConvert.DeserializeObject<AccountViewModel>(json)!;
                return account;
            }
            else
            {
                // Xử lý khi có lỗi trong yêu cầu
                string errorContent = await response.Content.ReadAsStringAsync();
                JObject errorObject = JObject.Parse(errorContent);
                string errorMessage = errorObject["message"]!.ToString();
                throw new Exception(errorMessage);
            }
        }

        public async Task<AccountViewModel> Register(RegisterRequest request)
        {
            string apiUrl = "/api/accounts/register";
            string jsonString = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                AccountViewModel account = JsonConvert.DeserializeObject<AccountViewModel>(json)!;
                return account;
            }
            else
            {
                // Xử lý khi có lỗi trong yêu cầu
                string errorContent = await response.Content.ReadAsStringAsync();
                JObject errorObject = JObject.Parse(errorContent);
                string errorMessage = errorObject["message"]!.ToString();
                throw new Exception(errorMessage);
            }
        }
    }
}