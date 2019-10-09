using System;
using System.Globalization;
using System.Text;
using Calculator.Interfaces;

namespace Calculator
{
    class Calculator : ICalculator
    {
        private readonly IСalculateHelper _сalculateHelper;
        private readonly IOperatorBuilder _operatorBuilder;
        private readonly StringBuilder _expression = new StringBuilder();

        public Calculator(IСalculateHelper сalculateHelper, IOperatorBuilder operatorBuilder)
        {
            _сalculateHelper = сalculateHelper;
            _operatorBuilder = operatorBuilder;
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
                var expression = _expression.ToString();

                var @operator = _operatorBuilder.CreateOperator(expression);
                var result = _сalculateHelper.Calculate(@operator);
                WriteLine(result.ToString(CultureInfo.CurrentCulture), ConsoleColor.Green);
            }
            catch (Exception exception)
            {
                WriteLine(exception.Message, ConsoleColor.Red);
            }
            finally
            {
                _expression.Clear();
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