using GeoAPI.Entities;
using GeoAPI.Models;

namespace GeoAPI.Interfaces
{
    public interface IGeoService
    {
        public List<GeoMarker> GetAll();
        public List<MarkerModel> GetAllMarkers();
        public List<QuestionModel> GetQuestion(double Latitude, double Longitude);
        public ResponseModel GetAnswear(AnswerModel dto);

    }
}
