using Calculator.Enumerators;

namespace Calculator.Interfaces
{
    public interface IOperator
    {
        double? Result { get; }
        Operator LeftOperand { get; }
        Operator RightOperand { get; }
        ArithmeticOperation Operation { get; }
    }
}