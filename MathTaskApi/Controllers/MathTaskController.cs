using IO.Swagger.Models;
using MathTaskApi.Models;
using MathTaskApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MathTaskApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MathTaskController : Controller
    {
        public readonly IMathService _mathService;
        public MathTaskController(IMathService mathService)
        {
            _mathService = mathService;  
        }
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
            
            if (!Enum.TryParse<MathOperation>(xOperation, ignoreCase: true, out var operation))
                return BadRequest("Invalid operation type.");

            var result = _mathService.Calculate(body.Number1.Value, body.Number2.Value, operation);

            return Ok(new { result });

          
        }
    }
    
}
