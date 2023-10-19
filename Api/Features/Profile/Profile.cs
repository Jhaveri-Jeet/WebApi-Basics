using Api.Features.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Features.Profile
{
    public class Profile
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public long UserId { get; set; }

        public virtual User.User? User { get; set; }
    }
}
