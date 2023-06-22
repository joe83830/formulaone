using System.Diagnostics;

namespace FormulaOne.Data.Models
{
    public class Qualifying
    {
        public int QualifyId { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int ConstructorId { get; set; }
        public int Number { get; set; }
        public int Position { get; set; }
        public string? Q1 { get; set; }
        public string? Q2 { get; set; }
        public string? Q3 { get; set; }

        public Race Race { get; set; }
        public Driver Driver { get; set; }
        public Constructor Constructor { get; set; }
    }
}
