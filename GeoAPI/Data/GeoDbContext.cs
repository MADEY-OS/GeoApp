using Microsoft.EntityFrameworkCore;

namespace GeoAPI.Data
{
    public class GeoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "GeoDatabase");
        }

        public DbSet<GeoMarker> GeoMarkers { get; set; }
    }
}
