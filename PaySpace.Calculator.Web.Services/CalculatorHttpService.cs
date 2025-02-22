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
      throw new NotImplementedException();
    }

    public async Task<CalculateResult> CalculateTaxAsync(CalculateRequest calculationRequest)
    {
      throw new NotImplementedException();
    }
  }
}