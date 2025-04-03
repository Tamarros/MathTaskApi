using MathTaskApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
namespace MathTaskApi.Tests
{
    public class LoginControllerTests
    {
        private readonly LoginController _controller;

        public LoginControllerTests()
        {
            _controller = new LoginController();
        }

        [Fact]
        public void GenerateToken_ValidCredentials_ReturnsToken()
        {
            var request = new LoginRequest
            {
                Username = "admin",
                Password = "1234"
            };

            var result = _controller.GenerateToken(request) as OkObjectResult;

            Assert.NotNull(result);
            Assert.Contains("token", result.Value.ToString());
        }

        [Fact]
        public void GenerateToken_InvalidCredentials_ReturnsUnauthorized()
        {
            var request = new LoginRequest
            {
                Username = "wrong",
                Password = "wrong"
            };

            var result = _controller.GenerateToken(request);

            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
