using GeoAPI.Entities;
using GeoAPI.Interfaces;
using GeoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeoAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        private readonly IGeoService _geoService;

        public GeoController(IGeoService geoService)
        {
            _geoService = geoService;
        }


        [HttpGet]
        public ActionResult<List<GeoMarker>> GetAll()
        {
            return Ok(_geoService.GetAllMarkers());
        }

        [Route("markers")]
        [HttpGet]
        public ActionResult<List<MarkerModel>> GetAllMarkers()
        {
            return Ok(_geoService.GetAllMarkers());
        }


        [Route("question")]
        [HttpPost]
        public ActionResult GetQuestion([FromBody] CoordinatesModel dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _geoService.GetQuestion(dto.Latitude, dto.Longitude);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Coordinates does not exists!");
        }

        [Route("answear")]
        [HttpPost]
        public ActionResult GetAnswer([FromBody] AnswerModel dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _geoService.GetAnswear(dto);

            if (result != null)
            {
                if (result.Status == true) return Ok(result);
                if (result.Status == false) return Ok(result);
            }
            return BadRequest("Answear does not exists!");
        }
    }
}
