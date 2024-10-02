using Client.Model;
using Client.Services.Interface;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Client.Services
{
    public class ProductService : IBaseService<ProductRequest>
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductRequest>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductRequest>>(BaseUrl);
        }

        public async Task<bool> CreateAsync(ProductRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, request);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateAsync(ProductRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync(BaseUrl, request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
