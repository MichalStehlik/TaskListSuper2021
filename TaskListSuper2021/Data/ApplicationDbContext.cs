using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskListSuper2021.Models;

namespace TaskListSuper2021.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TaskItem> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TaskItem>(entity => {
                entity.HasOne(t => t.Author).WithMany(u => u.TasksCreated).HasForeignKey(t => t.AuthorId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(t => t.Receiver).WithMany(u => u.TasksGiven).HasForeignKey(t => t.ReceiverId).OnDelete(DeleteBehavior.Restrict);
            });
            // user seed
            builder.Entity<IdentityRole>().HasData(new IdentityRole { 
                Id = "98f3a634-70c1-4e75-a5d0-9fe86602c271",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "75a7ef87-2142-4a35-9f9f-eaea3f77c419",
                Email = "michal.stehlik@pslib.cz",
                NormalizedEmail = "MICHAL.STEHLIK@PSLIB.CZ",
                EmailConfirmed = true,
                UserName = "michal.stehlik@pslib.cz",
                NormalizedUserName = "MICHAL.STEHLIK@PSLIB.CZ",
                LockoutEnabled = false,
                SecurityStamp = String.Empty,
                PasswordHash = hasher.HashPassword(null, "Beruska")
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { 
                RoleId = "98f3a634-70c1-4e75-a5d0-9fe86602c271",
                UserId = "75a7ef87-2142-4a35-9f9f-eaea3f77c419"
            });
        }
    }
}
