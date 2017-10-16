using Shouldly;
using System;
using Xunit;

namespace TDDBank.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateInstance() => new Konto().ShouldNotBeNull();
        [Fact]
        public void New_Konto_Kontostand_shoud_be_0() => new Konto().Kontostand.ShouldBe(0m);
        [Fact]
        public void Einzahlen_50_Kontostand_should_be_50()
        {
            var konto = new Konto();

            konto.Einzahlen(50m);

            konto.Kontostand.ShouldBe(50m);
        }
        [Fact]
        public void Einzahlen_50_and_90_Kontostand_should_be_140()
        {
            var konto = new Konto();

            konto.Einzahlen(50m);
            konto.Einzahlen(90m);

            konto.Kontostand.ShouldBe(140m);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(-50)]
        [InlineData(-100)]
        [InlineData(-75489)]
        public void Einzahlen_negative_value_should_throw_ArgumentException(decimal value) 
            => Should.Throw<ArgumentException>(() => new Konto().Einzahlen(value));
        [Fact]
        public void Einzahlen_50_Auszahlen_35_Kontostand_should_be_15()
        {
            var konto = new Konto();
            konto.Einzahlen(50m);

            konto.Auszahlen(35m);

            konto.Kontostand.ShouldBe(15m);
        }
        [Fact]
        public void Einzahlen_80_Auszahlen_4_and_9Point3_Kontostand_should_be_66Point7()
        {
            var konto = new Konto();
            konto.Einzahlen(80m);

            konto.Auszahlen(4m);
            konto.Auszahlen(9.3m);

            konto.Kontostand.ShouldBe(66.7m);
        }
        [Theory]
        [InlineData(-0.000001)]
        [InlineData(-1)]
        [InlineData(-470)]
        [InlineData(-2457.53)]
        [InlineData(-12356.53)]
        public void Auszahlen_negative_value_should_throw_ArgumentException(decimal value)
            => Should.Throw<ArgumentException>(() => new Konto().Auszahlen(value));
        [Theory]
        [InlineData(1, 2)]
        [InlineData(9546.54, 10546.54)]
        [InlineData(526, 4775)]
        [InlineData(7333, 85621)]
        [InlineData(155, 200)]
        public void Auszahlen_more_than_Kontostand_should_throw_ArgumentException(decimal einzahlen, decimal auszahlen)
        {
            var konto = new Konto();
            konto.Einzahlen(einzahlen);

            Should.Throw<ArgumentException>(() => konto.Auszahlen(auszahlen));
        }
    }
}
