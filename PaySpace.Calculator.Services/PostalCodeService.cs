namespace PaySpace.Calculator.Services
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Caching.Memory;

  using PaySpace.Calculator.Data;
  using PaySpace.Calculator.Data.Models;
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class PostalCodeService(CalculatorContext context, IMemoryCache memoryCache) : IPostalCodeService
  {
    public async Task<List<PostalCode>> GetPostalCodesAsync()
    {
      var postalCodes = await memoryCache.GetOrCreateAsync("PostalCodes", entry =>
      {
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20);

        return context.PostalCodes
          .AsNoTracking()
          .ToListAsync();
      }) ?? [];

      return postalCodes;
    }

    public async Task<CalculatorType?> CalculatorTypeAsync(string code)
    {
      var postalCodes = await this.GetPostalCodesAsync();

      var postalCode = postalCodes.FirstOrDefault(pc => pc.Code == code);

      return postalCode?.Calculator;
    }
  }
}