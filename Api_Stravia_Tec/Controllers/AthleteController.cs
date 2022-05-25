using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Stravia_Tec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteController : ControllerBase
    {

        private static List<Athlete> athletes = new List<Athlete> {

            new Athlete{
                id = 1,
                birth_date = new DateTime(2018, 7, 25).ToString("dd-MM-yyyy"),
                name = "Jose",
                lname1 = "Mendoza",
                lname2 = "Mata",
                nationality = "Costarricense",
                password = "1234",
                photo = "un mapa de bits"
            },
            new Athlete{
                id = 2,
                birth_date = new DateTime(2018, 7, 25).ToString("dd-MM-yyyy"),
                name = "Juan",
                lname1 = "Jimenez",
                lname2 = "Solano",
                nationality = "Colombiano",
                password = "5678",
                photo = "un mapa de bits"
            }
        };
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

        //Request to get one athletes
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
            dbAthlete.lname1 = request.lname1;
            dbAthlete.lname2 = request.lname2;
            dbAthlete.name = request.name;
            dbAthlete.nationality = request.nationality;
            dbAthlete.password = request.password;
            dbAthlete.photo = request.photo;

            await context.SaveChangesAsync();

            return Ok(await context.Athletes.ToListAsync());
        }

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
