using ApiClient.Models;
using Domain.Models.FilteredOrders;
using Domain.Models.Orders;
using System.Text;
using System.Text.Json;

namespace ApiClient
{
    public class OrderExcecutorApiClient : IOrderExcecutorApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri;

        public OrderExcecutorApiClient(HttpClient httpClient, string baseUri)
        {
            _httpClient = httpClient;
            _baseUri = baseUri;
        }

        public async Task<List<OrderResponce>> InitializeFilteringAsync(DateTime timeAfterFirstOrder, string districtName, CancellationToken cancellationToken)
        {
            var uri = $"{_baseUri}/api/FilteredResults/initialize";
            var requestBody = new
            {
                timeAfterFirstOrder = timeAfterFirstOrder,
                districtName = districtName
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Server returned an error: {errorContent}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<List<OrderResponce>>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return orders;
        }

        public async Task<long> CreateOrderAsync(Guid uniqueNumber, int weight, DateTime deliveryTime, string districtName, CancellationToken cancellationToken)
        {
            var uri = $"{_baseUri}/api/Orders";

            var requestBody = new
            {
                UniqueNumber = uniqueNumber,
                Weight = weight,
                DeliveryTime = deliveryTime,
                DistrictName = districtName
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content, cancellationToken);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Server returned an error: {errorContent}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var orderId = JsonSerializer.Deserialize<long>(responseBody);

            return orderId;
        }

        public async Task<List<FilteredResult>> GetAllFilteredResultsAsync(CancellationToken cancellationToken)
        {
            var uri = $"{_baseUri}/api/FilteredResults";
            var response = await _httpClient.GetAsync(uri, cancellationToken);

            var responseBody = await response.Content.ReadAsStringAsync();
            var results = JsonSerializer.Deserialize<List<FilteredResult>>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return results;
        }
    }
}
