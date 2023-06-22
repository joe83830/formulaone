using System.Diagnostics;

namespace FormulaOne.Data.Models
{
    public class DriverStanding
    {
        public int DriverStandingsId { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public double Points { get; set; }
        public int Position { get; set; }
        public string PositionText { get; set; }
        public int Wins { get; set; }

        public Race Race { get; set; }
        public Driver Driver { get; set; }
    }
}
