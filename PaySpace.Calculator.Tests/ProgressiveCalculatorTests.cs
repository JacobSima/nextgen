namespace PaySpace.Calculator.Tests
{
  using NUnit.Framework;
  using PaySpace.Calculator.Services.Abstractions;
  using PaySpace.Calculator.Services.Calculators;

  [TestFixture]
  internal sealed class ProgressiveCalculatorTests
  {
    private IProgressiveCalculator progressiveCalculator;
    private static readonly List<(decimal from, decimal to, decimal rate)> settings =
    [
      (0m, 8350m, 10m),
      (8351m, 33950m, 15m),
      (33951m, 82250m, 25m),
      (82251m, 171550m, 28m),
      (171551m, 372950m, 33m),
      (372951m, decimal.MaxValue, 35m)
    ];

    [SetUp]
    public void Setup()
    {
      this.progressiveCalculator = new ProgressiveCalculator(settings);
    }

    [TestCase(-1, 0)]
    [TestCase(50, 5)]
    [TestCase(8350, 835)]
    [TestCase(8351, 835.15)]
    [TestCase(33951, 4675.25)]
    [TestCase(82251, 16750.28)]
    [TestCase(171550, 41734)]
    [TestCase(999999, 327683.15)]
    public async Task Calculate_Should_Return_Expected_Tax(decimal income, decimal expectedTax)
    {
      // Act
      var tax = this.progressiveCalculator.CalculateTax(income);

      // Assert
      Assert.That(tax, Is.EqualTo(expectedTax));
    }
  }
}