using System.ComponentModel;

namespace GeoAPI.Entities
{
    public class GeoMarker
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [DefaultValue("radio")]
        public string? Type { get; set; }
        [DefaultValue("Question")]
        public string? Question { get; set; }
        [DefaultValue("Answear")]
        public string? Answear { get; set; }
    }
}
