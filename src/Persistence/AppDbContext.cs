using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class AppDbContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Game>().HasMany(g => g.Genres).WithMany(g => g.Games);
            modelBuilder.Entity<Game>().HasMany(g => g.Developers).WithMany(g => g.Games);
            modelBuilder.Entity<Game>().HasMany(g => g.Languages).WithMany(g => g.Games);
            modelBuilder.Entity<Game>().HasMany(g => g.Platforms).WithMany(g => g.Games);
            modelBuilder.Entity<Game>().HasMany(g => g.Players).WithMany(g => g.Games);

            modelBuilder.Entity<Game>()
               .HasMany(g => g.Achievements)
               .WithOne(a => a.Game)
               .HasForeignKey(a => a.GameId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Game>()
               .HasMany(g => g.Ratings)
               .WithOne(a => a.Game)
               .HasForeignKey(a => a.GameId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<GameTime> GameTimes { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AchievementUser> AchievementUsers { get; set; }


    }
}
