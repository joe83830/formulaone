using System.ComponentModel.DataAnnotations;

namespace FormulaOne.Data.Models
{
    public class SprintResult
    {
        [Key]
        public int ResultId { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int ConstructorId { get; set; }
        public int Number { get; set; }
        public int Grid { get; set; }
        public int? Position { get; set; }
        public string? PositionText { get; set; }
        public int? PositionOrder { get; set; }
        public int Points { get; set; }
        public int Laps { get; set; }
        public string? Time { get; set; }
        public long? Milliseconds { get; set; }
        public int? FastestLap { get; set; }
        public string? FastestLapTime { get; set; }
        public int StatusId { get; set; }

        public Race Race { get; set; }
        public Driver Driver { get; set; }
        public Constructor Constructor { get; set; }
        public Status Status { get; set; }
    }
}
