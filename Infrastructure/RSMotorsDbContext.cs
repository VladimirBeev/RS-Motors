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
    }
}