namespace PaySpace.Calculator.Web.Services
{
  using System.Net.Http;
  using System.Net.Http.Json;
  using PaySpace.Calculator.Web.Services.Abstractions;
  using PaySpace.Calculator.Web.Services.Models;

  public class CalculatorHttpService(HttpClient _httpClient) : ICalculatorHttpService
  {
    public async Task<List<PostalCode>> GetPostalCodesAsync()
    {
      var response = await _httpClient.GetAsync(ApplicationConstants.HttpClients.postalCode);

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception($"Cannot fetch postal codes, status code: {response.StatusCode}");
      }

      var data = await response.Content.ReadFromJsonAsync<List<PostalCode>>() ?? [];

      return data;
    }

    public async Task<List<CalculatorHistory>> GetHistoryAsync()
    {
      var response = await _httpClient.GetAsync(ApplicationConstants.HttpClients.history);

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception($"Cannot fetch histories, status code: {response.StatusCode}");
      }

      var data = await response.Content.ReadFromJsonAsync<List<CalculatorHistory>>() ?? [];

      return data;
    }

    public async Task<CalculateResult> CalculateTaxAsync(CalculateRequest calculationRequest)
    {
      var response = await _httpClient.PostAsJsonAsync(ApplicationConstants.HttpClients.calculator, calculationRequest);

      if (!response.IsSuccessStatusCode)
      {
        throw new Exception($"Cannot calculate, status code: {response.StatusCode}");
      }

      var data = await response.Content.ReadFromJsonAsync<CalculateResult>();

      return data ?? throw new Exception("Failed to deserialize the response.");
    }

  }
}