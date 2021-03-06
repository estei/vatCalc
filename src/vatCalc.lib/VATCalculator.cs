﻿using System;

namespace vatCalc.lib
{
    public static class VATCalculator
    {
        public static decimal AddVAT(decimal originalPrice, decimal vatPercentage)
        {    
            var vat = CalculateVAT(originalPrice, vatPercentage);
            return originalPrice + vat;
        }

        public static decimal SubtractVAT(decimal originalPrice, decimal vatPercentage)
        {    
            return (originalPrice / ( 100 + vatPercentage )) * 100;
        }

        private static decimal CalculateVAT(decimal price, decimal vatPercentage)
        {
            return (price / 100) * vatPercentage;
        }
    }
}
