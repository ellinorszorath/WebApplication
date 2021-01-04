using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Datalager.Models;

namespace Datalager
{
    public class DejtingContext : IdentityDbContext
    {
        public DejtingContext(DbContextOptions<DejtingContext> options) : base(options)
        {
        }

        public DbSet<Registrerad> Registrering { get; set; }
    }
}
