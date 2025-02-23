namespace PaySpace.Calculator.Services.Repositories
{
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using Microsoft.EntityFrameworkCore;
  using PaySpace.Calculator.Data;
  using PaySpace.Calculator.Data.Abstractions;
  using PaySpace.Calculator.Data.Entities.PostalCode;

  internal sealed class PostalCodeRepository(CalculatorContext context) : IPostalCodeRepository
  {
    public async Task<bool> AddAsync(PostalCode newPostalCode)
    {
      await context.PostalCodes.AddAsync(newPostalCode);
      int rowsAffected = await context.SaveChangesAsync();
      return rowsAffected > 0;
    }

    public async Task<bool> DeleteAsync(PostalCode postalCode)
    {
      context.PostalCodes.Remove(postalCode);
      int rowsAffected = await context.SaveChangesAsync();
      return rowsAffected > 0;
    }

    public async Task<List<PostalCode>> GetAllAsync()
    {
      var postalCodes = await context.PostalCodes
        .AsNoTracking()
        .ToListAsync();

      return postalCodes;
    }

    public async Task<PostalCode> GetByIdAsync(long postalCodeId)
    {
      var postalCode = await context.PostalCodes
        .AsNoTracking()
        .FirstOrDefaultAsync(postalCode => postalCode.Id == postalCodeId);

      return postalCode ?? new PostalCode();
    }

    public async Task<bool> UpdateAsync(PostalCode postalCode)
    {
      context.PostalCodes.Update(postalCode);
      int rowsAffected = await context.SaveChangesAsync();
      return rowsAffected > 0;
    }
  }
}
