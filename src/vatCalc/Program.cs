using System;
using vatCalc.lib;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var operation = args[0];
            var price = decimal.Parse(args[1]);
            var vatPercentage = decimal.Parse(args[2]);

            if(operation == "add")
            {
                var result = VATCalculator.AddVAT(price, vatPercentage);
                Console.WriteLine(result);
            }else if( operation == "subtract")
            {
                var result = VATCalculator.SubtractVAT(price, vatPercentage);
                Console.WriteLine(result);
            }else
            {
                Console.WriteLine($"{operation} not a valid operation (add, subtract)");
            }
        }
    }
}
