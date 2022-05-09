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
    public class ActivityController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var activity = new Activity
            {
                id = 1,
                date = new DateTime(2020, 7, 25).ToString("dd-MM-yyyy"),
                hour = new DateTime(2020, 7, 25).ToString("HH:mm:ss"),
                duration = "2 hours",
                mileage = 200,
                traveled = 150,
                type = "longitud"
            };

            return Ok(activity);
        } 
    }
}