using IO.Swagger.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MathTaskApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MathTaskController : Controller
        { 
        /// <summary>
        /// Perform a math operation on two numbers
        /// </summary>
        /// <param name="body"></param>
        /// <param name="xOperation">The operation to perform</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid input or operation</response>
        /// <response code="401">Unauthorized</response>
        [HttpPost]
        [Route("/calculate")]
            //[ValidateModelState]
            public virtual IActionResult Calculate([FromBody]CalculateBody body, [FromHeader][Required()]string xOperation)
        {
            if (body == null)
            {
                return BadRequest("Request body is missing.");
            }

            decimal result;


            try
            {
                result = xOperation.ToLower() switch
                {
                    "add" => body.Number1.Value + body.Number2.Value,
                    "subtract" => body.Number1.Value - body.Number2.Value,
                    "multiply" => body.Number1.Value * body.Number2.Value,
                    "divide" => body.Number2.Value != 0
                        ? body.Number1.Value / body.Number2.Value
                        : throw new ArgumentException("Cannot divide by zero"),
                    _ => throw new ArgumentException("Unsupported operation")
                };
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return Ok(new { result });
        }
    }
    
}
