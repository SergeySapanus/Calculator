namespace Calculator.Interfaces
{
    interface ICalculator
    {
        void Clear();
        void CalculateExpression();
        void UpdateExpression(char symbol);
    }
}