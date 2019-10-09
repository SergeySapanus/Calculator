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
        private static readonly IClient _client = new Client(new СalculateHelper(), new OperatorBuilder());

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
                        _client.Clear();
                        break;
                    case '=':
                        _client.CalculateExpression();
                        break;
                    default:
                        _client.UpdateExpression(key.KeyChar);
                        break;
                }
            }
        }
    }
}
