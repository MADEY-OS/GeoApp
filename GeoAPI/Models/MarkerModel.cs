namespace GeoAPI.Models
{
    public class MarkerModel
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Question { get; set; }
    }
}
