using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.API.Entities
{
    public class UserRole : IdentityUserRole<Guid>
    {
        [NotMapped]
        public Role Role { get; set; }

        [NotMapped]
        public User User { get; set; }
    }
}