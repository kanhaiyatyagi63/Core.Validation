using Core.Validation.Attributes;

namespace Core.Validation
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class TestModel
    {
        public int Id { get; set; }
        [DateTimeAttribute]
        public string? DateTime { get; set; } = String.Empty;
        public DateTime ParsedDateTime
        {
            get
            {
                DateTime dateTime;
                System.DateTime.TryParseExact(DateTime, "MMddyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateTime);
                return dateTime;
            }
        }
    }
}
