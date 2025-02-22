namespace PaySpace.Calculator.Application.Helpers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public static class GetEnumValueHelper
  {
    public static List<EnumOption> GetEnumOptions<TEnum>()
      where TEnum : Enum
    {
      return Enum.GetValues(typeof(TEnum))
        .Cast<TEnum>()
        .Select(enumValue => new EnumOption { Value = Convert.ToInt32(enumValue), Label = enumValue.ToString() })
        .ToList();
    }
  }
}
