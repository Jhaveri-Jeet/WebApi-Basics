using Api.Features.Profile;
using System.ComponentModel.DataAnnotations;

namespace Api.Features.User
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

    }
}
