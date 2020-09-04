using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZedCrest_Dev_Challenge.Models;
using ZedCrest_Dev_Challenge.Services.Interface;

namespace ZedCrest_Dev_Challenge.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzz _fizzBuzz;
       
        public FizzBuzzController(IFizzBuzz fizzBuzz)
        {
            _fizzBuzz = fizzBuzz;
        }


        /// <summary>
        /// This end point accepts numbers from 1 to 100. If the Number is not a multiple of 3 or 5, it returns the number. But for multiples of three return the word "Fizz" instead of the number and for the multiples of five return "Buzz". For numbers which are multiples of both three and five return "FizzBuzz".
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Buzzed([FromBody] Request req)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please ensure you're passing a valid number");

            Response<string> _resp = new Response<string>();
            var result = _fizzBuzz.Buzz(req.Number);

            if (result.Item1) // Text Was returned
            {
                _resp.Message = "success";
                _resp.Data = result.Item2;
                return Ok(_resp);
            }
            else if (result.Item1 == false && result.Item2 == string.Empty && result.Item3 == 0 ) 
            {
                _resp.Message = "error";
                _resp.Data = "No match";
                return BadRequest(_resp);
            }
            else
            {
                _resp.Message = "success";
                _resp.Data = result.Item3.ToString();
                return Ok(_resp);
            }
          
        }
    }
}
