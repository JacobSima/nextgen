namespace PaySpace.Calculator.Services
{
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Data.Entities.PostalCode;
  using PaySpace.Calculator.Data.Model;

  internal sealed class PostalCodeService(IPostalCodeRepository postalCodeRepository, IInMemoryCache memoryCache) : IPostalCodeService
  {
    public async Task<List<PostalCode>> GetPostalCodesAsync()
    {
      var postalCodes = await memoryCache.GetOrCreateAsync<List<PostalCode>>("PostalCodes", () => postalCodeRepository.GetAllAsync()) ?? [];

      return postalCodes;
    }

    public async Task<PostalCode> GetPostalCodeByIdAsync(int postalCodeId)
    {
      var id = long.Parse(postalCodeId.ToString());

      var postalCode = await memoryCache.GetOrCreateByIdAsync<PostalCode>(
        "PostalCodes",
        code => code.Id == id,
        () => postalCodeRepository.GetByIdAsync(id)
      );

      return postalCode ?? new PostalCode();
    }

    public async Task<PostalCode> AddPostalCodeAsync(PostalCodeServiceRequest newPostalCode)
    {
      var request = MapAddPostalCodeRequest(newPostalCode);

      var isAddedToCache = await memoryCache.AddAndCacheAsync<PostalCode>(
        "PostalCodes",
        () => postalCodeRepository.AddAsync(request),
        request
      );

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
      var existingPostalCode = await postalCodeRepository.GetByIdAsync(postalCodeId ?? 0);

      if (existingPostalCode == null)
      {
        return false;
      }

      Enum.TryParse<CalculatorType>(updatedPostalCode.Calculator, true, out var calculatorType);

      existingPostalCode.Code = updatedPostalCode?.Code ?? string.Empty;
      existingPostalCode.Calculator = calculatorType;

      var isUpdated = await postalCodeRepository.UpdateAsync(existingPostalCode);

      if (isUpdated)
      {
        memoryCache.UpdateValue<PostalCode>("PostalCodes", code => code.Id == existingPostalCode.Id, existingPostalCode => existingPostalCode);
      }

      return isUpdated;
    }

    public async Task<bool> DeletePostalCodeAsync(long postalCodeId)
    {
      var existingPostalCode = await postalCodeRepository.GetByIdAsync(postalCodeId); ;

      if (existingPostalCode == null)
      {
        return false;
      }

      var isDeleted = await postalCodeRepository.DeleteAsync(existingPostalCode);

      if (isDeleted)
      {
        memoryCache.RemoveValue<PostalCode>("PostalCodes", code => code.Id == existingPostalCode.Id);
      }

      return isDeleted;
    }

    public async Task<CalculatorType> GetCalculatorTypesByCodeAsync(string code)
    {
      var postalCodes = await this.GetPostalCodesAsync();

      var postal = postalCodes.FirstOrDefault(postalCode => postalCode.Code == code);

      return postal?.Calculator ?? new CalculatorType();
    }
  }
}