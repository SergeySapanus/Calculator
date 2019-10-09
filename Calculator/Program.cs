using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;

namespace Calculator
{
    class Program
    {
        private static readonly ICalculator Calculator = new Calculator(new СalculateHelper(), new OperatorBuilder());

        static void Main(string[] args)
        {
            //1.5+5*3.4-46/3.6 

            while (true)
            {
                var key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case 'c':
                    case 'C':
                        Calculator.Clear();
                        break;
                    case '=':
                        Calculator.CalculateExpression();
                        break;
                    default:
                        Calculator.UpdateExpression(key.KeyChar);
                        break;
                }
            }
        }
    }
}
