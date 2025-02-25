namespace PaySpace.Calculator.Tests
{
  using NUnit.Framework;
  using PaySpace.Calculator.Services.Abstractions;
  using PaySpace.Calculator.Services.Calculators;

  [TestFixture]
  internal sealed class FlatValueCalculatorTests
  {
    private IFlatValueCalculator flatValueCalculator;

    private static readonly List<(decimal from, decimal to, decimal rate)> settings =
    [
      (0m, 199999m, 5m),
      (200000m, decimal.MaxValue, 10000m)
    ];

    [SetUp]
    public void Setup()
    {
      this.flatValueCalculator = new FlatValueCalculator(settings);
    }

    [TestCase(-1, 0)]
    [TestCase(199999, 9999.95)]
    [TestCase(100, 5)]
    [TestCase(200000, 10000)]
    [TestCase(6000000, 10000)]
    public async Task Calculate_Should_Return_Expected_Tax(decimal income, decimal expectedTax)
    {
      // Act
      var tax = this.flatValueCalculator.CalculateTax(income);

      // Assert
      Assert.That(tax, Is.EqualTo(expectedTax));
    }
  }
}