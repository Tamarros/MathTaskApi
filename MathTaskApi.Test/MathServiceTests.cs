using MathTaskApi.Models;
using MathTaskApi.Service;

namespace MathTaskApi.Tests
{
    public class MathServiceTests
    {
        private readonly MathService _service;

        public MathServiceTests()
        {
            _service = new MathService();
        }

        [Fact]
        public void Add_TwoValidNumbers_ReturnsCorrectSum()
        {
            var result = _service.Calculate(2, 3, MathOperation.Add);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Subtract_TwoValidNumbers_ReturnsCorrectDifference()
        {
            var result = _service.Calculate(10, 4, MathOperation.Subtract);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Multiply_TwoValidNumbers_ReturnsCorrectProduct()
        {
            var result = _service.Calculate(3, 4, MathOperation.Multiply);
            Assert.Equal(12, result);
        }

        [Fact]
        public void Divide_TwoValidNumbers_ReturnsCorrectQuotient()
        {
            var result = _service.Calculate(10, 2, MathOperation.Divide);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _service.Calculate(10, 0, MathOperation.Divide));
            Assert.Equal("Cannot divide by zero", ex.Message);
        }
    }
}
