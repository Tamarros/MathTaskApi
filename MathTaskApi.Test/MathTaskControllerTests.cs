using MathTaskApi.Controllers;
using IO.Swagger.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

public class MathTaskControllerTests
{
    private readonly MathTaskController _controller;

    public MathTaskControllerTests()
    {
        _controller = new MathTaskController(new MathService());
    }

    [Fact]
    public void Calculate_Addition_ReturnsCorrectResult()
    {
        // Arrange
        var body = new CalculateBody { Number1 = 5, Number2 = 3 };
        var xOperation = "add";

        // Act
        var result = _controller.Calculate(body, xOperation) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        var json = result.Value.ToString();
        Assert.Contains("8", json);
    }

    [Fact]
    public void Calculate_UnsupportedOperation_ReturnsBadRequest()
    {
        var body = new CalculateBody { Number1 = 1, Number2 = 2 };
        var result = _controller.Calculate(body, "invalid") as BadRequestObjectResult;

        Assert.NotNull(result);
    }

    [Fact]
    public void Calculate_NullBody_ReturnsBadRequest()
    {
        var result = _controller.Calculate(null, "add") as BadRequestObjectResult;

        Assert.NotNull(result);
    }
}
