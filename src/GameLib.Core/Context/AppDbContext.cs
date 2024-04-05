using GameLib.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameLib.Core.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasMany(g => g.Genres).WithMany(g => g.Games);
            modelBuilder.Entity<Game>().HasMany(g => g.Developers).WithMany(g => g.Games);
            modelBuilder.Entity<Game>().HasMany(g => g.Languages).WithMany(g => g.Games);
            modelBuilder.Entity<Game>().HasMany(g => g.Platforms).WithMany(g => g.Games);
            modelBuilder.Entity<Game>().HasMany(g => g.Players).WithMany(g => g.Games);
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<GameTime> GameTimes { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AchievementUser> AchievementUsers { get; set; }


    }
}
