using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Features.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : Controller
    {
        private readonly DatabaseContext databaseContext;
        public ProfilesController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profile = await databaseContext.Profiles.Include(profile => profile.User).ToListAsync();
            return Ok(profile);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var profile = await databaseContext.Profiles.Select(profile => new ProfileDto
            {
                Id = profile.Id,
                Description = profile.Description,
            }).FirstOrDefaultAsync(p => p.Id == id);

            if (profile == null)
                return NotFound();

            return Ok(profile);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AddProfile([FromRoute] int userId, [FromBody] Profile profile)
        {
            var user = await databaseContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user is null)
                return NotFound();

            profile.User = user;

            await databaseContext.Profiles.AddAsync(profile);
            await databaseContext.SaveChangesAsync();

            return Ok("Profile added!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile([FromBody] Profile profiles, [FromRoute] int id)
        {
            var profile = await databaseContext.Profiles.FirstOrDefaultAsync(p => p.Id == id);
            if (profile is null)
                return NotFound();

            profile.Name = profiles.Name;
            profile.Description = profiles.Description;
            profile.UserId = profiles.UserId;

            await databaseContext.SaveChangesAsync();
            return Ok("Profile Updated !");
        }

    }
}
