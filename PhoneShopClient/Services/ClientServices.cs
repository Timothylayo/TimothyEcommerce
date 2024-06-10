using PhoneShopSharedLib.Conracts;
using PhoneShopSharedLib.Models;
using PhoneShopSharedLib.Response;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PhoneShopClient.Services
{
    public class ClientServices : Iproduct
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/product";

        public ClientServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private static string SerializeObj(object modelObject) => JsonSerializer.Serialize(modelObject, JsonOptions());

        private static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;

        private static StringContent GenerateStringContent(string serializedObj) => new(serializedObj, System.Text.Encoding.UTF8, "application/json");

        private static IList<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IList<T>>(jsonString, JsonOptions())!;

        private static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            };
        }

        public async Task<ServiceResponse> AddProduct(Product model)
        {
            var response = await _httpClient.PostAsync(BaseUrl, GenerateStringContent(SerializeObj(model)));
            //read response
            if (!response.IsSuccessStatusCode)
                return new ServiceResponse(false, "Error occured. Try again later...");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceResponse>(apiResponse);
        }

        public async Task<List<Product>> GetAllProducts(bool featuredProducts)
        {
                var response = await _httpClient.GetAsync($"{BaseUrl}?featured={featuredProducts}");
                if (!response.IsSuccessStatusCode) return null!;

                var result = await response.Content.ReadAsStringAsync();
                return new List<Product>(DeserializeJsonStringList<Product>(result));
        }
    }
}

