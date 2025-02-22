namespace PaySpace.Calculator.Services
{
  using MapsterMapper;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Caching.Memory;

  using PaySpace.Calculator.Data;
  using PaySpace.Calculator.Data.Entities.PostalCode;
  using PaySpace.Calculator.Data.Model;
  using PaySpace.Calculator.Services.Abstractions;

  internal sealed class PostalCodeService(CalculatorContext context, IMemoryCache memoryCache, IMapper mapper) : IPostalCodeService
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

    public async Task<PostalCode> GetPostalCodeByIdAsync(int postalCodeId)
    {
      var postalCodes = await memoryCache.GetOrCreateAsync($"PostalCodes:{postalCodeId}", entry =>
      {
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20);

        return context.PostalCodes
          .AsNoTracking()
          .FirstOrDefaultAsync(postalCode => postalCode.Id == postalCodeId);
      });

      return postalCodes ?? new PostalCode();
    }

    public async Task<PostalCode> AddPostalCodeAsync(PostalCodeServiceRequest newPostalCode)
    {
      var request = MapAddPostalCodeRequest(newPostalCode);

      await context.PostalCodes.AddAsync(request);
      await context.SaveChangesAsync();

      memoryCache.Set($"PostalCodes:{request.Id}", request,
        new MemoryCacheEntryOptions
        {
          AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20)
        });

      return request;
    }

    private static PostalCode MapAddPostalCodeRequest(PostalCodeServiceRequest newPostalCode)
    {
      Enum.TryParse<CalculatorType>(newPostalCode.Calculator, true, out var calculatorType);

      var request = new PostalCode
      {
        Code = newPostalCode?.Code ?? string.Empty,
        Calculator = calculatorType
      };

      return request;
    }

    public async Task<bool> UpdatePostalCodeAsync(long? postalCodeId, PostalCodeServiceRequest updatedPostalCode)
    {
      var existingPostalCode = await context.PostalCodes.FindAsync(postalCodeId);

      if (existingPostalCode == null)
      {
        return false;
      }

      Enum.TryParse<CalculatorType>(updatedPostalCode.Calculator, true, out var calculatorType);

      existingPostalCode.Code = updatedPostalCode.Code;
      existingPostalCode.Calculator = calculatorType;

      await context.SaveChangesAsync();

      memoryCache.Set($"PostalCodes:{postalCodeId}", existingPostalCode,
        new MemoryCacheEntryOptions
        {
          AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(20)
        });

      return true;
    }

    public async Task<bool> DeletePostalCodeAsync(long postalCodeId)
    {
      var existingPostalCode = await context.PostalCodes.FindAsync(postalCodeId);

      if (existingPostalCode == null)
      {
        return false;
      }

      context.PostalCodes.Remove(existingPostalCode);
      await context.SaveChangesAsync();

      memoryCache.Remove($"PostalCodes:{postalCodeId}");

      return true;
    }

    public async Task<CalculatorType> GetCalculatorTypesByCodeAsync(string code)
    {
      var postalCodes = await this.GetPostalCodesAsync();

      var postal = postalCodes.FirstOrDefault(postalCode => postalCode.Code == code);

      return postal.Calculator;
    }
  }
}