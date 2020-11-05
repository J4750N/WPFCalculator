using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculator
{
    static class MathService
    {

        public static double Add(double x1, double x2) => x1 + x2;
        public static double Subtract(double x1, double x2) => x1 - x2;
        public static double Multiply(double x1, double x2) => x1 * x2;
        public static double Divide(double x1, double x2)
        {

            if (x1 == 0) // Have to force the exception cause it refuses to throw it by itself
                throw new DivideByZeroException("Can't divide by zero");

            return x1 / x2;
        }
        
    }
}