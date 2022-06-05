using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Stravia_Tec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteController : ControllerBase
    {

        private readonly DataContext context;

        public AthleteController(DataContext context) {
            this.context = context;
        }

        //Request to get all athletes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await context.Athletes.ToListAsync());
        }

        //Request to get one athlete by their id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var athlete = await context.Athletes.FindAsync(id);
            if (athlete == null)
                return BadRequest("athlete not found");
            return Ok(athlete);
        }

        //Request to login as one athlete
        
        [HttpPost("login")]
        public async Task<IActionResult> Get(Athlete athlete)
        {

            var dbathlete = await context.Athletes
                .Where(a => a.username == athlete.username && a.password == athlete.password)
                .ToListAsync();

            if (dbathlete.Count == 0) { 
                    return Ok("Las credenciales son incorrectas, intentelo de nuevo");
            }
            return Ok(dbathlete);
        }

        //Request to search an athlete by their username
        [HttpPost("searchAthlete")]
        public async Task<IActionResult> searchAthlete(String athleteName)
        {

            var dbathlete = await context.Athletes
                .Where(a => a.username == athleteName)
                .ToListAsync();

            if (dbathlete.Count == 0)
            {
                return Ok("Las credenciales son incorrectas, intentelo de nuevo");
            }
            return Ok(dbathlete);
        }

        //Request to add one athlete to athletes, registration of the athlete
        [HttpPost]
        public async Task<IActionResult> addAthlete(Athlete athlete)
        {

            context.Athletes.Add(athlete);
            await context.SaveChangesAsync();
            return Ok(await context.Athletes.ToListAsync());
        }

        //Request to update an athlete
        [HttpPut]
        public async Task<IActionResult> updateAthlete(Athlete request)
        {
            var dbAthlete = await context.Athletes.FindAsync(request.id);
            if (dbAthlete == null)
                return BadRequest("athlete not found");

            dbAthlete.id = request.id;
            dbAthlete.username = request.username;
            dbAthlete.password = request.password;
            dbAthlete.fname = request.fname;
            dbAthlete.lname = request.lname;
            dbAthlete.category = request.category;
            dbAthlete.birth_date = request.birth_date;
            dbAthlete.current_age = request.current_age;
            dbAthlete.nationality = request.nationality;
            dbAthlete.photo = request.photo;

            dbAthlete.Activities = request.Activities;
            dbAthlete.ActivityId = request.ActivityId;

            await context.SaveChangesAsync();

            return Ok(await context.Athletes.ToListAsync());
        }

        //Delete request to delete an athlete by their id
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAthlete(int id)
        {

            var dbAthlete = await context.Athletes.FindAsync(id);
            if (dbAthlete == null)
                return BadRequest("athlete not found");

            context.Athletes.Remove(dbAthlete);

            await context.SaveChangesAsync();

            return Ok(await context.Athletes.ToListAsync());
        }

    }
}
