namespace Calculator
{
    interface IClient
    {
        void Clear();
        void CalculateExpression();
        void UpdateExpression(char symbol);
    }
}