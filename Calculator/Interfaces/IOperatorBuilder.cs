namespace Calculator.Interfaces
{
    public interface IOperatorBuilder
    {
        Operator CreateOperator(string expression);
    }
}