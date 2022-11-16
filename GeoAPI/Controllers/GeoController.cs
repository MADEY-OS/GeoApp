using GeoAPI.Data;
using GeoAPI.Interfaces;
using GeoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeoAPI.Controllers
{
    [Route("api/markers")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        readonly IGeoService _geoService;

        public GeoController(IGeoService geoService)
        {
            _geoService = geoService;
        }

        [HttpGet]
        public ActionResult<List<GeoMarker>> GetAll()
        {
            return Ok(_geoService.GetAll());
        }

        [Route("question")]
        [HttpPost]
        public ActionResult GetQuestion([FromBody] CoordinatesModel dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var context = new GeoDbContext();

            var question = context.GeoMarkers.FirstOrDefault(r => r.Latitude == dto.Latitude && r.Longitude == dto.Longitude);

            if (question != null)
            {
                return Ok(_geoService.GetQuestion(question));
            }
            return BadRequest("Coordinates does not exists!");
        }

        [Route("answer")]
        [HttpPost]
        public ActionResult GetAnswer([FromBody] AnswerModel dto)
        {
            var context = new GeoDbContext();

            var answear = context.GeoMarkers.FirstOrDefault(a => a.Id.ToString() == dto.Id);

            if (answear != null)
            {
                var result = new ResponseModel
                {
                    Id = dto.Id,
                };

                if (dto.Answear == answear.Answear)
                {
                    result.Status = true;
                    return Ok(result);
                }
                result.Status = false;
                return NotFound(result);
            }
            return BadRequest("Answear does not exists!");
        }




    }
}
