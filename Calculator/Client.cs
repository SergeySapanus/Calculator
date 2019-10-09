using System;
using System.Globalization;
using System.Text;

namespace Calculator
{
    class Client : IClient
    {
        private readonly IСalculateHelper _сalculateHelper;
        private readonly StringBuilder _expression = new StringBuilder();

        public Client(IСalculateHelper сalculateHelper)
        {
            _сalculateHelper = сalculateHelper;
        }

        public void Clear()
        {
            _expression.Clear();
            Console.Clear();
        }

        public void CalculateExpression()
        {
            try
            {
                var random = new Random();
                var result = _сalculateHelper.Add(random.NextDouble(), random.NextDouble());
                WriteLine(result.ToString(CultureInfo.CurrentCulture), ConsoleColor.Green); ;
            }
            catch (Exception exception)
            {
                WriteLine(exception.Message, ConsoleColor.Red);
            }
        }

        public void UpdateExpression(char symbol)
        {
            _expression.Append(symbol);
        }

        private static void WriteLine(string text, ConsoleColor foregroundColor)
        {
            var original = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;

            Console.WriteLine(text);
            Console.ForegroundColor = original;
        }
    }
}