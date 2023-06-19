using System.Diagnostics;

namespace FormulaOne.Data.Models
{
    public class ConstructorStanding
    {
        public int ConstructorStandingsId { get; set; }
        public int RaceId { get; set; }
        public int ConstructorId { get; set; }
        public int Points { get; set; }
        public int Position { get; set; }
        public string PositionText { get; set; }
        public int Wins { get; set; }

        public Race Race { get; set; }
        public Constructor Constructor { get; set; }
    }
}
