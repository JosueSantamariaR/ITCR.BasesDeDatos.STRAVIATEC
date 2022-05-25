using Microsoft.AspNetCore.Mvc;

namespace Api_Stravia_Tec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly DataContext context;

        public ActivityController(DataContext context)
        {
            this.context = context;
        }

        //Request to get all activties form db
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await context.Activities.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int activityId)
        {
            return Ok(context);
        }

    }
}
