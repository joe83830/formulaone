namespace FormulaOne.Data.DTOs
{
    public class DriverLapTimeDTO
    {
        public int lap { get; set; }
        public int lapTimeId { get; set; }
        public int milliseconds { get; set; }
        public int position { get; set; }
        public int raceId { get; set; }
        public string name { get; set; }
    }
}
