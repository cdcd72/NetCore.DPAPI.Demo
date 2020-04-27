namespace Web.Models
{
    public class Region
    {
        public string EncryptedId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public WeatherForecast WeatherForecast { get; set; }
    }
}
