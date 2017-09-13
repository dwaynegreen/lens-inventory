using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace SeeMoreInventory.Models
{
    public class LensContext : DbContext
    {
        public LensContext(DbContextOptions<LensContext> options) : base(options)
        {

        }

        public DbSet<Lens> Lenses { get; set; }

    }
}