using System.Collections.Generic;
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
            Lens lens = Get(productLabel);

            LensHistory lensHistoryToUpdate = new LensHistory();

            lensHistoryToUpdate.Axis = lens.Axis;
            lensHistoryToUpdate.AntiReflectiveCoating = lens.AntiReflectiveCoating;
            lensHistoryToUpdate.Cylinder = lens.Cylinder;
            lensHistoryToUpdate.Material = lens.Material;
            lensHistoryToUpdate.ProductLabel = lens.ProductLabel;
            lensHistoryToUpdate.Sphere = lens.Sphere;
            lensHistoryToUpdate.RemainingCount = lens.RemainingCount;
            lensHistoryToUpdate.Quantity = quantity;

            lensHistoryToUpdate.InsertDate = DateTime.Now;

            LensHistory.Add(lensHistoryToUpdate);
            SaveChanges();
        }

        public IQueryable<LensHistory> GetTodaysHistory()
        {
            var today = DateTime.Now.Date;
            return
                LensHistory.Where(x => x.InsertDate >= today && x.InsertDate <= DateTime.Today.AddDays(1).Date).OrderByDescending(x => x.InsertDate);
        }
    }
}