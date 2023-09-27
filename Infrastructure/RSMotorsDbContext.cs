using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using RSMotors.Infrastructure.Models;

namespace RSMotors.Infrastructure
{
    public class RSMotorsDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public RSMotorsDbContext(DbContextOptions<RSMotorsDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Customer)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CustomerId)
                .IsRequired();

            modelBuilder.Entity<Car>()
                .HasMany(c => c.Payment)
                .WithOne(c => c.Car)
                .HasForeignKey(c => c.CarId)
                .IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}