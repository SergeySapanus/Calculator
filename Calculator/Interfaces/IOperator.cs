using Calculator.Enumerators;

namespace Calculator.Interfaces
{
    public interface IOperator
    {
        double? Result { get; }
        IOperator LeftOperand { get; }
        IOperator RightOperand { get; }
        ArithmeticOperation Operation { get; }
    }
}