using System;
using Calculator.Enumerators;
using Calculator.Interfaces;

namespace Calculator
{
    class СalculateHelper : IСalculateHelper
    {
        public double Calculate(IOperator @operator)
        {
            if (@operator.Result.HasValue)
                return @operator.Result.Value;

            var operation = GetOperation(@operator.Operation);
            return operation(Calculate(@operator.LeftOperand), Calculate(@operator.RightOperand));
        }

        private Func<double, double, double> GetOperation(Operation operation)
        {
            switch (operation)
            {
                case Operation.Add:
                    return Add;
                case Operation.Subtract:
                    return Subtract;
                case Operation.Multiply:
                    return Multiply;
                case Operation.Divide:
                    return Divide;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }

        private double Add(double operandLeft, double operandRight)
        {
            return operandLeft + operandRight;
        }

        private double Subtract(double operandLeft, double operandRight)
        {
            return operandLeft - operandRight;
        }

        private double Multiply(double operandLeft, double operandRight)
        {
            return operandLeft * operandRight;
        }

        private double Divide(double operandLeft, double operandRight)
        {
            return operandLeft / operandRight;
        }
    }
}