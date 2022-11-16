using GeoAPI.Data;
using GeoAPI.Models;

namespace GeoAPI.Interfaces
{
    public interface IGeoService
    {
        public List<GeoMarker> GetAll();
        public List<QuestionModel> GetQuestion(GeoMarker marker);

    }
}
