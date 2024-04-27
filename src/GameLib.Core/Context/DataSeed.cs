using GameLib.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameLib.Core.Context
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            var (ADMIN_ROLE_ID, USER_ROLE_ID) = _seedRoles(builder);

            _seedUsers(builder, ADMIN_ROLE_ID, USER_ROLE_ID);

        }
        private static (Guid, Guid) _seedRoles(ModelBuilder builder)
        {
            var ADMIN_ROLE_ID = Guid.NewGuid();
            var USER_ROLE_ID = Guid.NewGuid();
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = ADMIN_ROLE_ID.ToString()
                },
                new IdentityRole<Guid>
                {
                    Id = USER_ROLE_ID,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = USER_ROLE_ID.ToString()
                }
            );
            return (ADMIN_ROLE_ID, USER_ROLE_ID);
        }
        private static Guid _seedUsers(ModelBuilder builder, Guid ADMIN_ROLE_ID, Guid USER_ROLE_ID)
        {
            var ADMIN_ID = Guid.NewGuid();
            var USER_ID = Guid.NewGuid();
            var admin = new User
            {

                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                FirstName = "Admin",
                LastName = "Admin",
                NormalizedUserName = "admin@admin.com".ToUpper(),
                EmailConfirmed = true,
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            var user = new User
            {
                Id = USER_ID,
                UserName = "user@gmail.com",
                FirstName = "User",
                LastName = "User",
                NormalizedUserName = "user@gmail.com".ToUpper(),
                EmailConfirmed = true,
                Email = "user@gmail.com",
                NormalizedEmail = "user@gmail.com".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            PasswordHasher<User> ph = new PasswordHasher<User>();

            admin.PasswordHash = ph.HashPassword(admin, "Admin$23");
            user.PasswordHash = ph.HashPassword(user, "Admin$23");

            builder.Entity<User>()
                .HasData(admin, user);

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                }
            );
            return ADMIN_ID;
        }
    }
}
