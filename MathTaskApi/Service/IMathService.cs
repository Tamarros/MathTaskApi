﻿using MathTaskApi.Models;
namespace MathTaskApi.Service
{
    public interface IMathService
    {
        decimal Calculate(decimal number1, decimal number2, MathOperation operation);
    }
}