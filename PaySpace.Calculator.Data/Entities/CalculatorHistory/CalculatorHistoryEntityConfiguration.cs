namespace PaySpace.Calculator.Data.Entities.CalculatorHistory
{
  using System;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;

  internal class CalculatorHistoryEntityConfiguration : IEntityTypeConfiguration<CalculatorHistory>
  {
    public void Configure(EntityTypeBuilder<CalculatorHistory> builder)
    {
      builder
        .ToTable("CalculatorHistory");

      builder
        .HasKey(ch => ch.Id);

      builder
        .Property(ch => ch.Id)
        .HasColumnName("Id")
        .ValueGeneratedOnAdd();

      builder
        .Property(ch => ch.PostalCode)
        .HasColumnName("PostalCode")
        .IsRequired()
        .HasColumnType("TEXT");

      builder
        .Property(ch => ch.Timestamp)
        .HasColumnName("Timestamp")
        .IsRequired()
        .HasConversion(v => v.ToString("yyyy-MM-dd HH:mm:ss"),  // Store as TEXT in DB
          v => DateTime.Parse(v));

      builder
        .Property(ch => ch.Income)
        .HasColumnName("Income")
        .IsRequired()
        .HasColumnType("TEXT");  // Keeps it as TEXT in DB

      builder
        .Property(ch => ch.Tax)
        .HasColumnName("Tax")
        .IsRequired()
        .HasColumnType("TEXT");  // Keeps it as TEXT in DB

      builder
        .Property(ch => ch.Calculator)
        .HasColumnName("Calculator")
        .IsRequired()
        .HasConversion<int>();  // Stores Enum as INTEGER
    }
  }
}
