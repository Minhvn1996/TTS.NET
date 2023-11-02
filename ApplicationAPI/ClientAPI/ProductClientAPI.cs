using NetAPI.Data.Entities;
using NetAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ApplicationAPI.ClientAPI
{
    public class ProductClientAPI
    {
        private HttpClient _client;

        public ProductClientAPI()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:5000/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<ProductViewModel>> GetList()
        {
            string apiUrl = "/api/products/getAll";
            HttpResponseMessage response = await _client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<ProductViewModel> list = JsonConvert.DeserializeObject<List<ProductViewModel>>(json)!;
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

        public async Task<Pagination<ProductViewModel>> GetListPaging(string filter, int pageIndex = 1, int pageSize = 10)
        {
            string apiUrl = $"api/products/paging?filter={filter}&pageIndex={pageIndex}&pageSize={pageSize}";
            HttpResponseMessage response = await _client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Pagination<ProductViewModel> paging = JsonConvert.DeserializeObject<Pagination<ProductViewModel>>(json)!;
                return paging;
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

        public async Task<ProductViewModel> GetById(int id)
        {
            string apiUrl = $"api/products/{id}";
            HttpResponseMessage response = await _client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                ProductViewModel product = JsonConvert.DeserializeObject<ProductViewModel>(json)!;
                return product;
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

        public async Task<Product> Delete(int id)
        {
            string apiUrl = $"api/products/{id}";
            HttpResponseMessage response = await _client.DeleteAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Product product = JsonConvert.DeserializeObject<Product>(json)!;
                return product;
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

        public async Task<ProductViewModel> AddProduct(ProductRequest request)
        {
            string apiUrl = "/api/products/";
            string jsonString = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                ProductViewModel product = JsonConvert.DeserializeObject<ProductViewModel> (json)!;
                return product;
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

        public async Task<Product> UpdateProduct(int id, ProductRequest request)
        {
            string apiUrl = $"/api/products/{id}";
            string jsonString = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Product product = JsonConvert.DeserializeObject<Product>(json)!;
                return product;
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

        public async Task<List<Product>> ImportList(List<ProductRequest> request)
        {
            string apiUrl = "/api/products/import";
            string jsonString = JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json)!;
                return products;
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