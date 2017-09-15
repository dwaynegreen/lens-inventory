using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace SeeMoreInventory.Models
{
    public class LensContext : DbContext
    {
        public LensContext(DbContextOptions<LensContext> options) : base(options)
        {
            
        }

        public DbSet<Lens> Lenses { get; set; }
        public DbSet<LensHistory> LensHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}