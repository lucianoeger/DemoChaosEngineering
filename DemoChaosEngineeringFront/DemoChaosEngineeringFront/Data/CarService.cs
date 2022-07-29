using System.Text;
using System.Text.Json;

namespace DemoChaosEngineeringFront.Data
{
    public class CarService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public CarService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            var response = await _client.GetAsync("/api/cars");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException(content);
            
            return JsonSerializer.Deserialize<List<Car>>(content, _options);
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            var response = await _client.GetAsync($"/api/cars/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException(content);
            
            return JsonSerializer.Deserialize<Car>(content, _options);
        }

        public async Task UpdateCarAsync(Car car)
        {
            var response = await _client.PutAsync($"/api/cars/{car.Id}", new StringContent(JsonSerializer.Serialize(car), Encoding.UTF8, "application/json"));
            if(!response.IsSuccessStatusCode)
                throw new ApplicationException(await response.Content.ReadAsStringAsync());
        }

        public async Task DeleteCarAsync(int id)
        {
            var response = await _client.DeleteAsync($"/api/cars/{id}");
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException(await response.Content.ReadAsStringAsync());
        }
    }
}