using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiStraviaTec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var athlete = new Athlete
            {
                id = 1, 
                birthdate = new DateTime(2018,7,25).ToString("dd-MM-yyyy"),
                name = "Jose",
                lname1 = "Mendoza",
                lname2 = "Mata",
                nationality = "Costarricense",
                password = "1234",
                photo = "un mapa de bits"
            };

            return Ok(athlete);
        }
    }
}