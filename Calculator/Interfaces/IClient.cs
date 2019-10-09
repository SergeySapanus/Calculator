namespace Calculator.Interfaces
{
    interface IClient
    {
        void Clear();
        void CalculateExpression();
        void UpdateExpression(char symbol);
    }
}