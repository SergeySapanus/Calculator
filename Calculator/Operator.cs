using Calculator.Enumerators;
using Calculator.Interfaces;

namespace Calculator
{
    public class Operator : IOperator
    {
        public Operator(double result)
        {
            Result = result;
        }

        public Operator(Operator leftOperand, Operator rightOperand, ArithmeticOperation operation)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Operation = operation;
        }

        public double? Result { get; private set; }

        public Operator LeftOperand { get; private set; }

        public Operator RightOperand { get; private set; }

        public ArithmeticOperation Operation { get; private set; }
    }
}