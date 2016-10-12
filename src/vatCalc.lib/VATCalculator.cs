using System;

namespace vatCalc.lib
{
    public static class VATCalculator
    {
        public static double AddVAT(double originalPrice, double vatPercentage)
        {    
            var vat = CalculateVAT(originalPrice, vatPercentage);
            return originalPrice + vat;
        }

        public static double SubtractVAT(double originalPrice, double vatPercentage)
        {    
            var vat = CalculateVAT(originalPrice, vatPercentage);
            return originalPrice - vat;
        }

        private static double CalculateVAT(double price, double vatPercentage)
        {
            return (price / 100) * vatPercentage;
        }
    }
}
