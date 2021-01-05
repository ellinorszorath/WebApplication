using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Datalager.Models;
using Microsoft.AspNetCore.Identity;

namespace Datalager
{
    public partial class DejtingContext : IdentityDbContext<IdentityUser>
    {
        public DejtingContext(DbContextOptions<DejtingContext> options) : base(options)
        {
        }

        public DbSet<Registrerad> Registrering { get; set; }
    }
}
