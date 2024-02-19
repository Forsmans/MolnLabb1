namespace CV.Models.Weather
{
    public class Current
    {
        public DateTime Time { get; set; }
        public int Interval { get; set; }
        public double Temperature_2m { get; set; }
        public double Rain { get; set; }
    }
}
