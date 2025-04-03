public class MathService : IMathService
{
    public decimal Calculate(decimal number1, decimal number2, string operation)
    {
        return operation.ToLower() switch
        {
            "add" => number1 + number2,
            "subtract" => number1 - number2,
            "multiply" => number1 * number2,
            "divide" => number2 != 0
                ? number1 / number2
                : throw new ArgumentException("Cannot divide by zero"),
            _ => throw new ArgumentException("Unsupported operation")
        };
    }
}
