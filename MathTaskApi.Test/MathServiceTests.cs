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
            var result = _service.Calculate(2, 3, "add");
            Assert.Equal(5, result);
        }

        [Fact]
        public void Subtract_TwoValidNumbers_ReturnsCorrectDifference()
        {
            var result = _service.Calculate(10, 4, "subtract");
            Assert.Equal(6, result);
        }

        [Fact]
        public void Multiply_TwoValidNumbers_ReturnsCorrectProduct()
        {
            var result = _service.Calculate(3, 4, "multiply");
            Assert.Equal(12, result);
        }

        [Fact]
        public void Divide_TwoValidNumbers_ReturnsCorrectQuotient()
        {
            var result = _service.Calculate(10, 2, "divide");
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _service.Calculate(10, 0, "divide"));
            Assert.Equal("Cannot divide by zero", ex.Message);
        }

        [Fact]
        public void UnsupportedOperation_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _service.Calculate(10, 2, "modulo"));
            Assert.Equal("Unsupported operation", ex.Message);
        }
    }
}
