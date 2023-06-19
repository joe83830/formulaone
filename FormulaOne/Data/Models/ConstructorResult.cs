using System.Diagnostics;

namespace FormulaOne.Data.Models
{
    public class ConstructorResult
    {
        public int ConstructorResultsId { get; set; }
        public int RaceId { get; set; }
        public int ConstructorId { get; set; }
        public int Points { get; set; }
        public string Status { get; set; }

        public Race Race { get; set; }
        public Constructor Constructor { get; set; }
    }
}
