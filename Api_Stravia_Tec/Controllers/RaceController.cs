using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Stravia_Tec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {

        private readonly DataContext context;

        public RaceController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/Race
        //Request to get all Races in the database
        [HttpGet]
        public async Task<IActionResult> getAllRaces()
        {
            return Ok(await context.Races.ToListAsync());
        }

        // GET: api/<RaceController>
        //Request to get all a Race by his id
        [HttpGet("{id}")]
        public async Task<IActionResult> getRace(int id)
        {
            var race = await context.Races.FindAsync(id);
            if (race == null)
                return BadRequest("athlete not found");

            return Ok(race);
        }

        //Request to add one race to Races table, registration of the Race
        [HttpPost]
        public async Task<IActionResult> addRace(Race race)
        {

            context.Races.Add(race);
            await context.SaveChangesAsync();
            return Ok(await context.Races.ToListAsync());
        }

        //Request to search a race by their username
        [HttpPost("searchRace")]
        public async Task<IActionResult> searchRace(String raceName)
        {

            var dbrace = await context.Races
                .Where(r => r.Name == raceName)
                .ToListAsync();

            if (dbrace.Count == 0)
            {
                return BadRequest("La carrera especificada no existe");
            }
            return Ok(dbrace);
        }

        //Request to update a race using the id of the request body to search it on the database
        [HttpPut]
        public async Task<IActionResult> updateRace(Race request)
        {
            var dbRace = await context.Races.FindAsync(request.Id);
            if (dbRace == null)
                return BadRequest("Race not found");

            dbRace.Id = request.Id;
            dbRace.Name = request.Name;
            dbRace.date = request.date;
            dbRace.route = request.route;
            dbRace.isPrivate = request.isPrivate;
            dbRace.cost = request.cost;
            dbRace.Organizers = request.Organizers;
            dbRace.bank_accounts = request.bank_accounts;
            dbRace.status = request.status;

            dbRace.Organizers = request.Organizers;
            dbRace.activityType = request.activityType;
            dbRace.category = request.category;

            await context.SaveChangesAsync();

            return Ok(await context.Races.ToListAsync());
        }

        //Delete request to delete a Race by their id
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteRace(int id)
        {

            var dbRace = await context.Races.FindAsync(id);
            if (dbRace == null)
                return BadRequest("Race not found");

            context.Races.Remove(dbRace);

            await context.SaveChangesAsync();

            return Ok(await context.Races.ToListAsync());
        }

    }
}
