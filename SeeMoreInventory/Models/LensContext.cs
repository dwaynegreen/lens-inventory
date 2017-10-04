using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace SeeMoreInventory.Models
{
    public class LensContext : DbContext
    {
        public LensContext(DbContextOptions<LensContext> options) : base(options)
        {
            
        }

        public DbSet<Lens> Lenses { get; set; }
        public DbSet<LensHistory> LensHistory { get; set; }
        public DbSet<MaterialType> Materials { get; set; }

        public Lens Get(string productLabel)
        {
            Lens v = Lenses.FirstOrDefault(l => l.ProductLabel.ToLower() == productLabel.ToLower());
            return v;
        }

        public bool ValidateLens(string productLabel)
        {
            return Lenses.Any(l => l.ProductLabel == productLabel);
        }

        public void DecrementInventory(string productLabel, int count)
        {
            Lens lensToDecrement = Get(productLabel);
            lensToDecrement.RemainingCount += count;
            SaveChanges();
        }

        public void IncrementInventory(string productLabel, int count)
        {
            Lens lensToIncrement = Get(productLabel);
            lensToIncrement.RemainingCount += count;
            SaveChanges();
        }

        public void UpdateHistory(string productLabel, int quantity)
        {
            var lens = Lenses.Where(l => l.ProductLabel == productLabel).Include(m => m.Material).ToList();

            LensHistory lensHistoryToUpdate = new LensHistory
            {
                ProductLabel = lens[0].ProductLabel,
                Sphere = lens[0].Sphere,
                Cylinder = lens[0].Cylinder,
                AntiReflectiveCoating = lens[0].AntiReflectiveCoating,
                Transitions = lens[0].Transitions,
                Axis = lens[0].Axis,
                Material = lens[0].Material,
                Quantity = quantity,
                RemainingCount = lens[0].RemainingCount,
                InsertDate = DateTime.Now
            };
            LensHistory.Add(lensHistoryToUpdate);
            SaveChanges();
        }

        public IQueryable<LensHistory> GetTodaysHistory()
        {
            var today = DateTime.Now.Date;
            return
                LensHistory.Where(x => x.InsertDate >= today && x.InsertDate <= DateTime.Today.AddDays(1).Date).OrderByDescending(x => x.InsertDate).Include(m => m.Material);
        }

        public MaterialType GetMaterialByName(string materialName)
        {
            return Materials.Where(n => n.Name == materialName).FirstOrDefault();
        }
    }
}