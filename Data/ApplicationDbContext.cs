using BDolma_SMS.EntityConfiguration;
using BDolma_SMS.Models;
using BDolma_SMS.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BDolma_SMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext)
            : base(dbContext)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<ApplicationUser> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(e => e.MiddleName)
                .HasMaxLength(255);

            builder.Entity<ApplicationUser>()
                .Property(e => e.LastName)
                .HasMaxLength(255)
                .IsRequired();



            builder.Entity<ApplicationUser>()
                .Property(e => e.Address)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(e => e.UserRoleId)
                .HasMaxLength(255)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(e => e.IsActive)
                .HasDefaultValue(true);


            builder.Entity<ApplicationUser>()
                .Property(e => e.PictureUrl)
                .HasMaxLength(255);

            builder.Entity<ApplicationUser>()
                .Property(e => e.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");


            builder.Entity<IdentityRole>()
                .ToTable("Roles")
                .Property(p => p.Id)
                .HasColumnName("RoleId");

            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}
