using Application.Untils;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistance
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            var (ADMIN_ROLE_ID, USER_ROLE_ID) = _seedRoles(builder);

            _seedUsers(builder, ADMIN_ROLE_ID, USER_ROLE_ID);
            _seedLanguage(builder);

        }
        private static (Guid, Guid) _seedRoles(ModelBuilder builder)
        {
            var ADMIN_ROLE_ID = Guid.NewGuid();
            var USER_ROLE_ID = Guid.NewGuid();
            builder.Entity<RoleEntity>().HasData(
                new RoleEntity
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",

                },
                new RoleEntity
                {
                    Id = USER_ROLE_ID,
                    Name = "User",
                }
            );
            return (ADMIN_ROLE_ID, USER_ROLE_ID);
        }
        private static void _seedUsers(ModelBuilder builder, Guid ADMIN_ROLE_ID, Guid USER_ROLE_ID)
        {
            var ADMIN_ID = Guid.NewGuid();
            var USER_ID = Guid.NewGuid();
            var admin = new UserEntity
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                RoleId = ADMIN_ROLE_ID
            };
            var user = new UserEntity
            {
                Id = USER_ID,
                UserName = "user@gmail.com",
                FirstName = "User",
                LastName = "User",
                Email = "user@gmail.com",
                RoleId = USER_ROLE_ID
            };

            admin.PasswordHash = PasswordHasher.Hash("Admin$23");
            user.PasswordHash = PasswordHasher.Hash("User$23");

            builder.Entity<UserEntity>().HasData(user, admin);

            // Seed the relationships
        }


        private static Guid _seedLanguage(ModelBuilder builder)
        {
            var ENGLISH_ID = Guid.NewGuid();
            var POLISH_ID = Guid.NewGuid();
            builder.Entity<Language>().HasData(
                new Language
                {
                    Id = ENGLISH_ID,
                    Title = "English",

                },
                new Language
                {
                    Id = POLISH_ID,
                    Title = "Polish",

                },
                new Language
                {
                    Id = Guid.NewGuid(),
                    Title = "German",

                },
                new Language
                {
                    Id = Guid.NewGuid(),
                    Title = "French",

                },
                new Language
                {
                    Id = Guid.NewGuid(),
                    Title = "Spanish",

                },
                new Language
                {
                    Id = Guid.NewGuid(),
                    Title = "Italian",

                },
                new Language
                {
                    Id = Guid.NewGuid(),
                    Title = "Ukraine",

                }
            );
            return ENGLISH_ID;
        }
    }
}
