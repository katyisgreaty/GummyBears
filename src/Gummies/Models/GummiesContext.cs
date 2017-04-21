using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Gummies.Models
{
    public class GummiesContext : DbContext
    {
        public GummiesContext()
        {
        }

        public DbSet<Gummy> Gummies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Gummies;integrated security=True");
        }

        public GummiesContext(DbContextOptions<GummiesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
