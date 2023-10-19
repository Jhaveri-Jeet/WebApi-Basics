using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Api.Features.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly DatabaseContext databaseContext;
        public UsersController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await databaseContext.Users.AddAsync(user);
            await databaseContext.SaveChangesAsync();
            return Ok("User Added !");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await databaseContext.Users.ToListAsync();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();

            databaseContext.Remove(user);
            await databaseContext.SaveChangesAsync();
            return Ok("User Deleted !");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] User user)
        {
            var users = await databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (users == null)
                return NotFound();

            users.Name = user.Name;
            users.PasswordHash = user.PasswordHash;

            await databaseContext.SaveChangesAsync();

            return Ok("User Updated !");
        }
    }
}
