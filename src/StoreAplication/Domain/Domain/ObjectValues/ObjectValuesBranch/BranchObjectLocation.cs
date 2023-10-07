namespace Domain.ObjectValues
{
    public class BranchObjectLocation
    {
        public string Country { get; set; }
        public string City { get; set; }

        public BranchObjectLocation(string country, string city)
        {
            Country = country;
            City = city;
        }
    }
}
