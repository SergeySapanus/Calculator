using System;
using System.Text;
using Calculator.Enumerators;
using Calculator.Interfaces;

namespace Calculator
{
    public class OperatorBuilder : IOperatorBuilder
    {
        const char End = 'p';

        #region Fields

        char[] _expression;
        int _expressionLength;
        int _currentIndex = -1;
        char _currentSymbol;

        #endregion Fields

        public IOperator CreateOperator(string expression)
        {
            _expression = expression.ToCharArray();
            _expressionLength = _expression.Length;
            _currentIndex = -1;

            return GetRegularOperand();
        }

        private IOperator GetRegularOperand()
        {
            var leftOperand = GetPriorityOperand();

            while (true)
            {
                switch (_currentSymbol)
                {
                    case '+':
                        {
                            var rightOperand = GetPriorityOperand();
                            leftOperand = new Operator(leftOperand, rightOperand, Operation.Add);
                        }
                        break;
                    case '-':
                        {
                            var rightOperand = GetPriorityOperand();
                            leftOperand = new Operator(leftOperand, rightOperand, Operation.Subtract);
                        }
                        break;
                    default:
                        {
                            _currentSymbol = GetNextSymbol();
                        }
                        break;
                }

                if (_currentSymbol == End)
                    break;
            }

            return leftOperand;
        }

        private IOperator GetPriorityOperand()
        {
            var leftOperand = new Operator(GetNumber());

            switch (_currentSymbol)
            {
                case '*':
                    {
                        var rightOperand = new Operator(GetNumber());
                        return new Operator(leftOperand, rightOperand, Operation.Multiply);
                    }
                case '/':
                    {
                        var rightOperand = new Operator(GetNumber());
                        return new Operator(leftOperand, rightOperand, Operation.Divide);
                    }
            }

            return leftOperand;
        }

        private char GetNextSymbol()
        {
            if (++_currentIndex == _expressionLength)
                return End;

            return _expression[_currentIndex];
        }

        private double GetNumber()
        {
            var stringBuilder = new StringBuilder();

            var beforeSeparatorNumber = 0;
            var hasSeparator = false;

            while (true)
            {

                _currentSymbol = GetNextSymbol();
                if (isDigit(_currentSymbol))
                {
                    stringBuilder.Append(_currentSymbol);
                }
                else if (IsPoint(_currentSymbol))
                {
                    beforeSeparatorNumber = int.Parse(stringBuilder.ToString());
                    stringBuilder.Clear();
                    hasSeparator = true;
                }
                else
                {
                    break;
                }
            }

            var local = stringBuilder.ToString();
            double result = int.Parse(local);

            if (hasSeparator && local.Length > 0)
                result = result / Math.Pow(10, local.Length);

            return beforeSeparatorNumber + result;
        }

        private bool isDigit(char ch)
        {
            return ch == '0' || ch == '1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6' || ch == '7' || ch == '8' || ch == '9';
        }

        private bool IsPoint(char ch)
        {
            return ch == '.' || ch == ',';
        }
    }
}