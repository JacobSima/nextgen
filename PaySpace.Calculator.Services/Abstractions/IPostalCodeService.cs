namespace PaySpace.Calculator.Services.Abstractions
{
  using PaySpace.Calculator.Data.Entities.PostalCode;
  using PaySpace.Calculator.Data.Model;

  public interface IPostalCodeService
  {
    Task<List<PostalCode>> GetPostalCodesAsync();

    Task<PostalCode> GetPostalCodeByIdAsync(int postalCodeId);

    Task<PostalCode> AddPostalCodeAsync(PostalCodeServiceRequest newPostalCode);

    Task<bool> UpdatePostalCodeAsync(long? postalCodeId, PostalCodeServiceRequest updatedPostalCode);

    Task<bool> DeletePostalCodeAsync(long postalCodeId);

    Task<CalculatorType> GetCalculatorTypesByCodeAsync(string code);
  }
}