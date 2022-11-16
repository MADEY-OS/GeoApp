namespace GeoAPI.Data
{
    public class GeoMarker
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Type { get; set; }
        public string Question { get; set; }
        public string Answear { get; set; }
    }
}
