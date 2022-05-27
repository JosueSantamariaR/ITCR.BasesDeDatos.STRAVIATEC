using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Stravia_Tec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly DataContext context;

        public ChallengeController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/Challenge
        //Request to get all Challenges in the database
        [HttpGet]
        public async Task<IActionResult> getAllChallenges()
        {
            return Ok(await context.Challenges.ToListAsync());
        }

        // GET: api/<ChallengeController>
        //Request to get a Challenge by his id
        [HttpGet("{id}")]
        public async Task<IActionResult> getChallenge(int id)
        {
            var challenge = await context.Challenges.FindAsync(id);
            if (challenge == null)
                return BadRequest("athlete not found");

            return Ok(challenge);
        }

        //Request to add one challenge to challenges table, registration of the challenge
        [HttpPost]
        public async Task<IActionResult> addChallenge(Challenge challenge)
        {
            try
            {
                context.Challenges.Add(challenge);
                await context.SaveChangesAsync();
                return Ok(await context.Challenges.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
            
        }

        //Request to search a challenge by their name
        [HttpPost("searchChallenge")]
        public async Task<IActionResult> searchChallenge(String challengeName)
        {

            var dbchallenge = await context.Challenges
                .Where(c => c.Name == challengeName)
                .ToListAsync();

            if (dbchallenge.Count == 0)
            {
                return BadRequest("La carrera especificada no existe");
            }
            return Ok(dbchallenge);
        }

        //Request to update a challenge using the id of the request body to search it on the database
        [HttpPut]
        public async Task<IActionResult> updateChallenge(Challenge request)
        {
            var dbchallenge = await context.Challenges.FindAsync(request.Id);
            if (dbchallenge == null)
                return BadRequest("Race not found");

            dbchallenge.Id = request.Id;
            dbchallenge.Name = request.Name;
            dbchallenge.period = request.period;
            dbchallenge.status = request.status;
            dbchallenge.isPrivate = request.isPrivate;
            dbchallenge.Organizers = request.Organizers;
            dbchallenge.activityType = request.activityType;

            await context.SaveChangesAsync();

            return Ok(await context.Challenges.ToListAsync());
        }

        //Delete request to delete a challenge by their id
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteChallenge(int id)
        {

            var dbchallenge = await context.Challenges.FindAsync(id);
            if (dbchallenge == null)
                return BadRequest("Race not found");

            context.Challenges.Remove(dbchallenge);

            await context.SaveChangesAsync();

            return Ok(await context.Challenges.ToListAsync());
        }

    }
}
