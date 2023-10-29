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
        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<RepairPart> RepairParts { get; set; } = null!;

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

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(8,2);

            modelBuilder.Entity<RepairPart>()
                .Property(p => p.Price)
                .HasPrecision(8, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}