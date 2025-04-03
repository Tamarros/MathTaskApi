using IO.Swagger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

            decimal result;


            result = _mathService.Calculate(body.Number1.Value, body.Number2.Value, xOperation);
           

            return Ok(new { result });
        }
    }
    
}
