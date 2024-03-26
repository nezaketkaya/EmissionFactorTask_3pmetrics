using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace EmissionFactorTask_3pmetrics.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<EmissionFactors> EmissionFactor { get; set; }
        public DbSet<EmissionMappings> EmissionMapping { get; set; }
        public DbSet<EmissionPoints> EmissionPoint { get; set; }
        public DbSet<EmissionSources> EmissionSource { get; set; }
        public DbSet<EmissionSourcesUnits> EmissionSourcesUnit { get; set; }
        public DbSet<Catalogs> Catalog { get; set; }

    }
}
