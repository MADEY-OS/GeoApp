using GeoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoAPI.Data
{
    public class GeoDbContext : DbContext
    {
        public GeoDbContext(DbContextOptions<GeoDbContext> options) : base(options) { }
        public DbSet<GeoMarker> GeoMarkers { get; set; }
    }
}
