using Authentication.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication.API.Data
{
    public class AuthenticationDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(ConfigureUser);

            builder.Entity<Role>(ConfigureRole);
            builder.Entity<UserRole>(ConfigureUserRole);


            builder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable(name: "UserClaims");
            });
            builder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
            });
            builder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable(name: "UserRoleClaims");
            });
            builder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable(name: "UserTokens");
            });
        }

        private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(name: "UserRoles");
        }

        private void ConfigureRole(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(name: "Roles");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).HasMaxLength(64);

            //each role can have many entries in the userrole joint table
            builder.HasMany(u=>u.UsersForRole)
                .WithOne(e=>e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.HasMany(u=> u.RolesForUser)
                .WithOne(e=>e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        }
    }
}
