using System;
using Xunit;
using vatCalc.lib;

namespace vatCalc.test
{
    public class VATCalculatorTests
    {
        [Fact]
        public void Adding_25_percent_VAT_to_100_is_125() 
        {
            Assert.Equal(125, VATCalculator.AddVAT(100, 25));
        }

        [Fact]
        public void Adding_20_percent_VAT_to_200_is_240() 
        {
            Assert.True(VATCalculator.AddVAT(200, 20) == 240);
        }

        [Theory]
        [InlineData(100, 25, 80.0)]
        [InlineData(100, 20, "83.33333333333333333333333333")]
        public void Subtracting(decimal value, decimal percentage, decimal result)
        {
            Assert.Equal(result, VATCalculator.SubtractVAT(value, percentage));
        }
    }
}
