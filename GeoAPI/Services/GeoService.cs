using GeoAPI.Data;
using GeoAPI.Interfaces;
using GeoAPI.Models;

namespace GeoAPI.Services
{
    public class GeoService : IGeoService
    {
        public GeoService()
        {
            using (var context = new GeoDbContext())
            {
                var markers = new List<GeoMarker>
                {
                    new GeoMarker
                    {
                        Id = Guid.NewGuid(),
                        Longitude= 49.78367127477706,
                        Latitude= 19.057652630685222,
                        Type = "radio",
                        Question = "Czy Niggerozaur ma 500 zębów?",
                        Answear = "Tak"
                    },
                    new GeoMarker
                    {
                        Id = Guid.NewGuid(),
                        Longitude= 50.034776755453386,
                        Latitude= 19.17584109840639,
                        Type = "radio",
                        Question = "Czy Auschwitz i Birkenau to, to same miejsce?",
                        Answear = "Nie"
                    },
                    new GeoMarker
                    {
                        Id = Guid.NewGuid(),
                        Longitude= 49.8163527014621,
                        Latitude= 19.043706150706086,
                        Type = "radio",
                        Question = "Czy w Bielsku-Białej jeździły tramwaje?",
                        Answear = "Tak"
                    },
                    new GeoMarker
                    {
                        Id = Guid.NewGuid(),
                        Longitude= 49.97842286306948,
                        Latitude= 18.930352711897914,
                        Type = "radio",
                        Question = "Czy w Parku Pszczyńskim są żubry?",
                        Answear = "Tak"
                    },
                    new GeoMarker
                    {
                        Id = Guid.NewGuid(),
                        Longitude= 49.8212552621617,
                        Latitude= 19.042701130935647,
                        Type = "radio",
                        Question = "Czy Bielsko-Biała należy do województwa Małopolskiego?",
                        Answear = "Nie"
                    }
                };
                context.GeoMarkers.AddRange(markers);
                context.SaveChanges();
            }
        }
        public List<GeoMarker> GetAll()
        {
            using (var context = new GeoDbContext())
            {
                var list = context.GeoMarkers.ToList();
                return list;
            }
        }

        public List<QuestionModel> GetQuestion(GeoMarker marker)
        {
            using (var context = new GeoDbContext())
            {
                var result = new List<QuestionModel>
                {
                    new QuestionModel
                    {
                        Id = marker.Id,
                        Type = marker.Type,
                        Question = marker.Question
                    }
                };
                return result;
            }
        }
    }
}

