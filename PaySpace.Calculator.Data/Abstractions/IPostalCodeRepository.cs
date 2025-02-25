namespace PaySpace.Calculator.Data.Abstractions
{
  using PaySpace.Calculator.Data.Entities.PostalCode;

  public interface IPostalCodeRepository
  {
    Task<List<PostalCode>> GetAllAsync();
    Task<PostalCode> GetByIdAsync(long postalCodeId);
    Task<bool> AddAsync(PostalCode newPostalCode);
    Task<bool> DeleteAsync(PostalCode postalCode);
    Task<bool> UpdateAsync(PostalCode postalCode);
  }
}
