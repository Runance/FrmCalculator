using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CalculatorApplication.CalculatorClass;

namespace CalculatorApplication
{
    public class CalculatorClass
    {
        public delegate T Formula<T>(T arg1, T arg2);

     
        public event Formula<double> CalculateEvent;

       
        public double PerformCalculation(double num1, double num2)
        {
            if (CalculateEvent != null)
            {
                return CalculateEvent(num1, num2);
            }
            else
            {
                throw new InvalidOperationException("No operation selected.");
            }
        }

       
        public double GetSum(double num1, double num2)
        {
            return num1 + num2;
        }


        public double GetDifference(double num1, double num2)
        {
            return num1 - num2;
        }


        public double GetProduct(double num1, double num2)
        {
            return num1 * num2;
        }


        public double GetQuotient(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return num1 / num2;
        }
    }
}