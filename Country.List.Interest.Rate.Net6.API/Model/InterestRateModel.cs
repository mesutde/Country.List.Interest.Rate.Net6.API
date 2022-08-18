namespace Country.List.Interest.Rate.Net6.API.Model
{
    public class InterestRateModel
    {
        public string Country { get; set; }
        public double Last { get; set; }
        public double Previous { get; set; }
        public String Reference { get; set; }
        public String Unit { get; set; }
    }
}