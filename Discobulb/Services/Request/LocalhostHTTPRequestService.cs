using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Discobulb.Services.Request
{
    public class LocalhostHTTPRequestService : IRequestService
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("http://localhost/api/newdeveloper")
        };

        public async Task<JsonArray?> GetJsonArrayAsync(string path)
        {
            var response = await _httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JsonArray?>(responseString);
            }
            return null;
        }

        public async Task<JsonObject?> GetJsonObjectAsync(string path)
        {
            var response = await _httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JsonObject?>(responseString);
            }
            return null;
        }

        public async Task<bool> PutJsonAsync(string path, JsonObject json)
        {
            StringContent content = new(json.ToJsonString(), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(path, content);

            return response.IsSuccessStatusCode;
        }
    }
}
