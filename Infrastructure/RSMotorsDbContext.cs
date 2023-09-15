using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RSMotors.Data
{
    public class RSMotorsDbContext : IdentityDbContext
    {
        public RSMotorsDbContext(DbContextOptions<RSMotorsDbContext> options)
            : base(options)
        {
        }
    }
}