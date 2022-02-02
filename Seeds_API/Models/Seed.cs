using System.Globalization;

namespace Seeds_API.Models
{
    public class Seed
    {

        public string? SeedType { get; set; }
        public double SeedLevel { get; set; }
        public string? SeedStatus { get; set; }
        public DateTime PlantingDate { get; set; }

    }

}