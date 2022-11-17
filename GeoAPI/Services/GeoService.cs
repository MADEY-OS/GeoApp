using AutoMapper;
using GeoAPI.Data;
using GeoAPI.Entities;
using GeoAPI.Interfaces;
using GeoAPI.Models;

namespace GeoAPI.Services
{
    public class GeoService : IGeoService
    {
        private readonly GeoDbContext _dbContext;
        private readonly IMapper _mapper;

        public GeoService(GeoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GeoMarker> GetAll()
        {
            var result = _dbContext.GeoMarkers.ToList();
            return result;
        }

        public List<MarkerModel> GetAllMarkers()
        {
            var markers = _dbContext.GeoMarkers.ToList();
            var result = _mapper.Map<List<MarkerModel>>(markers);
            return result;
        }

        public List<QuestionModel> GetQuestion(double latitude, double longitude)
        {

            var marker = _dbContext.GeoMarkers.FirstOrDefault(r => r.Latitude == latitude && r.Longitude == longitude);

            if (marker == null) return null;

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

        public ResponseModel GetAnswear(AnswerModel dto)
        {
            var answear = _dbContext.GeoMarkers.FirstOrDefault(a => a.Id.ToString() == dto.Id);

            if (answear == null) return null;

            var result = new ResponseModel
            {
                Id = dto.Id.ToString()
            };

            if (dto.Answear == answear.Answear)
            {
                result.Status = true;
                return result;
            }
            result.Status = false;
            return result;

        }
    }
}

