namespace Calculator
{
    interface IСalculateHelper
    {
        double Add(double operandLeft, double operandRight);
        double Subtract(double operandLeft, double operandRight);
        double Multiply(double operandLeft, double operandRight);
        double Divide(double operandLeft, double operandRight);
    }
}