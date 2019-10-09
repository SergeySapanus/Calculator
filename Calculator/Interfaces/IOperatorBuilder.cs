namespace Calculator.Interfaces
{
    public interface IOperatorBuilder
    {
        IOperator CreateOperator(string expression);
    }
}