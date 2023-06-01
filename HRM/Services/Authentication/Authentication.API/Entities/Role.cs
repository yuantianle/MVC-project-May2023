using Microsoft.AspNetCore.Identity;
namespace Authentication.API.Entities
{
    // Admin, HR, Manager, Business Analyst, etc.
    public class Role : IdentityRole<Guid>
    {
        public ICollection<UserRole> UsersForRole { get; set; }

    }
}
