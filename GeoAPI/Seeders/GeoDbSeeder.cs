using GeoAPI.Data;
using GeoAPI.Entities;

namespace GeoAPI.Seeders
{
    public class GeoDbSeeder
    {
        private readonly GeoDbContext _dbContext;

        public GeoDbSeeder(GeoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var markers = SeedMarkers();

                if (!_dbContext.GeoMarkers.Any())
                {
                    _dbContext.GeoMarkers.AddRange(markers);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<GeoMarker> SeedMarkers()
        {
            var markers = new List<GeoMarker>
                {
                    new GeoMarker
                    {
                        Id = Guid.NewGuid(),
                        Latitude= 49.67732001208914,
                        Longitude= 19.012012477259102,
                        Type = "radio",
                        Question = "Czy Małe Skrzyczne należy do pasma gór Beskidu Śląskiego?",
                        Answear = "Tak"
                    },
                    new GeoMarker
                    {
                        Id = Guid.NewGuid(),
                        Latitude= 49.78323482948703,
                        Longitude= 19.057491696550258,
                        Type = "radio",
                        Question = "Czy ATH posiada wydział plastyki i hotelarstwa?",
                        Answear = "Nie"
                    },
                    new GeoMarker
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 49.8163527014621,
                        Longitude = 19.043706150706086,
                        Type = "radio",
                        Question = "Czy w Bielsku-Białej jeździły tramwaje?",
                        Answear = "Tak"
                    },
                    new GeoMarker
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 49.97842286306948,
                        Longitude = 18.930352711897914,
                        Type = "radio",
                        Question = "Czy w Parku Pszczyńskim są żubry?",
                        Answear = "Tak"
                    },
                    new GeoMarker
                    {
                        Id = Guid.NewGuid(),
                        Latitude = 49.8212552621617,
                        Longitude = 19.042701130935647,
                        Type = "radio",
                        Question = "Czy Bielsko-Biała należy do województwa Małopolskiego?",
                        Answear = "Nie"
                    }
                };
            return markers;
        }
    }
}

