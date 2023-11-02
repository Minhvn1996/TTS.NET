using NetAPI.Data.Entities;
using NetAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ApplicationAPI.ClientAPI
{
    public class CategoryClientAPI
    {
        private HttpClient _client;

        public CategoryClientAPI()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:5000/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Category>> GetList()
        {
            string apiUrl = "/api/categories/getAll";
            HttpResponseMessage response = await _client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<Category> list = JsonConvert.DeserializeObject<List<Category>>(json)!;
                return list;
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