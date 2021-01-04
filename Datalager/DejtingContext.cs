using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Datalager.Models;

namespace Datalager
{
    public class DejtingContext : DbContext
    {
        public DejtingContext(DbContextOptions<DejtingContext> options) : base(options)
        {
        }

        public DbSet<Person> Personer { get; set; }
    }
}
