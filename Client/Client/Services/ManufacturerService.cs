using Client.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace Client.Services
{
    public class ManufacturerService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/manufacturer";

        public ManufacturerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Manufacturer>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Manufacturer>>(BaseUrl);
        }

        public async Task<bool> CreateAsync(ManufacturerRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, request);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateAsync(ManufacturerRequest request)
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
