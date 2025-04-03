using MathTaskApi.Models;

namespace MathTaskApi.Service
{
    public class MathService : IMathService
    {
        public decimal Calculate(decimal number1, decimal number2, MathOperation operation)
        {
            return operation switch
            {
                MathOperation.Add => number1 + number2,
                MathOperation.Subtract => number1 - number2,
                MathOperation.Multiply => number1 * number2,
                MathOperation.Divide => number2 != 0 ? number1 / number2 : throw new ArgumentException("Cannot divide by zero"),
                _ => throw new ArgumentOutOfRangeException(nameof(operation), "Unsupported operation")
            };
        }
    }
}

