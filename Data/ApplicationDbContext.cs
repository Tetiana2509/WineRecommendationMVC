using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WineRecommendationMVC.Models;

namespace WineRecommendationMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WineSample> WineSamples { get; set; }
        public DbSet<WinePrediction> WinePredictions { get; set; }
        public DbSet<WineNote> WineNotes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<WinePrediction>()
                .HasOne(p => p.WineSample)
                .WithOne(s => s.WinePrediction)
                .HasForeignKey<WinePrediction>(p => p.WineSampleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
