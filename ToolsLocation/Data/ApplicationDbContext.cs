using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToolsLocation.Models;

namespace ToolsLocation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tool> Tools { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tool>().HasData(
                new Tool { ToolId = 1, Name = "Hitachi Drill", Brand = "Hitachi", Model = "DS 18DJL", LocationId = 1 },
                new Tool { ToolId = 2, Name = "Circular Saw", Brand = "Bosch", Model = "unknown", LocationId = 2 }
            );

            builder.Entity<Location>().HasData(
                new Location { LocationId = 1, ShelfName = "A", ShelfFloor = 0 },
                new Location { LocationId = 2, ShelfName = "B", ShelfFloor = 3 }

            );

            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser {
                    Id = "737a0dc2-5205-4893-90db-44a27135f11c",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "Popcorn_1")
                }

            );

        }
    }
}