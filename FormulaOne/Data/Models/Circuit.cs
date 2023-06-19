using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace FormulaOne.Data.Models
{
    public class Circuit
    {
        [Key]
        public int CircuitId { get; set; }
        public string CircuitRef { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int? Alt { get; set; }
        public string Url { get; set; }

        public ICollection<Race> Races { get; set; }
    }
}
