namespace PaySpace.Calculator.Tests
{
  using NUnit.Framework;
  using PaySpace.Calculator.Services.Abstractions;
  using PaySpace.Calculator.Services.Calculators;

  [TestFixture]
  internal sealed class FlatRateCalculatorTests
  {
    private IFlatRateCalculator flatRateCalculator;
    private static readonly List<(decimal from, decimal to, decimal rate)> settings =
    [
      (0m, decimal.MaxValue, 17.5m)
    ];

    [SetUp]
    public void Setup()
    {
      this.flatRateCalculator = new FlatRateCalculator(settings);
    }

    [TestCase(-1, 0)]
    [TestCase(999999, 174999.825)]
    [TestCase(1000, 175)]
    [TestCase(5, 0.875)]
    public async Task Calculate_Should_Return_Expected_Tax(decimal income, decimal expectedTax)
    {
      // Act
      var tax = this.flatRateCalculator.CalculateTax(income);

      // Assert
      Assert.That(tax, Is.EqualTo(expectedTax));
    }
  }
}