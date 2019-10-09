namespace Calculator
{
    class СalculateHelper : IСalculateHelper
    {
        public double Add(double operandLeft, double operandRight)
        {
            return operandLeft + operandRight;
        }

        public double Subtract(double operandLeft, double operandRight)
        {
            return operandLeft - operandRight;
        }

        public double Multiply(double operandLeft, double operandRight)
        {
            return operandLeft * operandRight;
        }

        public double Divide(double operandLeft, double operandRight)
        {
            return operandLeft / operandRight;
        }
    }
}