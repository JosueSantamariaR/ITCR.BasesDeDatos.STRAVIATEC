using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Stravia_Tec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly DataContext context;

        public GroupController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/Challenge
        //Request to get all groups in the database
        [HttpGet]
        public async Task<IActionResult> getAllGroups()
        {
            return Ok(await context.Groups.ToListAsync());
        }

        // GET: api/<GroupController>
        //Request to get a group by his id
        [HttpGet("{id}")]
        public async Task<IActionResult> getGroup(int id)
        {
            var group = await context.Groups.FindAsync(id);
            if (group == null)
                return BadRequest("group not found");

            return Ok(group);
        }

        //Request to add one group to groups table, registration of the group
        [HttpPost]
        public async Task<IActionResult> addGroup(Group group)
        {
            try
            {
                context.Groups.Add(group);
                await context.SaveChangesAsync();
                return Ok(await context.Groups.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }

        }

        //Request to search a Group by their name
        [HttpPost("searchGroup")]
        public async Task<IActionResult> searchGroup(String groupName)
        {

            var dbgroup = await context.Groups
                .Where(g => g.Name == groupName)
                .ToListAsync();

            if (dbgroup.Count == 0)
            {
                return BadRequest("El grupo especificada no existe");
            }
            return Ok(dbgroup);
        }

        //Request to update a Group using the id of the request body to search it on the database
        [HttpPut]
        public async Task<IActionResult> updateGroup(Group request)
        {
            var dbGroup = await context.Groups.FindAsync(request.Id);
            if (dbGroup == null)
                return BadRequest("Race not found");

            dbGroup.Id = request.Id;
            dbGroup.Name = request.Name;
            dbGroup.Administrator = request.Administrator;

            dbGroup.Organizers = request.Organizers;
            dbGroup.Activities = request.Activities;

            await context.SaveChangesAsync();

            return Ok(await context.Groups.ToListAsync());
        }

        //Delete request to delete a Group by their id
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteGroup(int id)
        {

            var dbGroup = await context.Groups.FindAsync(id);
            if (dbGroup == null)
                return BadRequest("Race not found");

            context.Groups.Remove(dbGroup);

            await context.SaveChangesAsync();

            return Ok(await context.Groups.ToListAsync());
        }
    }
}
