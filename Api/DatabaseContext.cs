using Api.Features.Profile;
using Api.Features.User;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
    }
}
