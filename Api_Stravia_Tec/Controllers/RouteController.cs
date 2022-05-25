
using Microsoft.AspNetCore.Mvc;

namespace Api_Stravia_Tec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly DataContext context;

        public RouteController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int activityId)
        {

            var routes = await context.Routes
                .Where(r => r.ActivityId == activityId)
                .ToListAsync();


            return Ok(routes);
        }

        [HttpPost]
        public async Task<IActionResult> addRoute(CreateRouteDto request)
        {

            var activity = await context.Activities.FindAsync(request.ActivityId);
            if (activity == null)
                return NotFound();

            var newRoute = new Route
            {
                origin = request.origin,
                destiny = request.destiny,
                Activity = activity
            };

            context.Routes.Add(newRoute);
            await context.SaveChangesAsync();

            return Ok(await Get(newRoute.ActivityId));
        }

    }
}
