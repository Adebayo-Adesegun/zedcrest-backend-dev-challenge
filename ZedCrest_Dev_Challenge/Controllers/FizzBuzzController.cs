using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZedCrest_Dev_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
       
        public FizzBuzzController()
        {

        }


        [HttpPost]
        public IActionResult Buzzed([FromBody] Request req)
        {
            return Ok();
        }
    }
}
