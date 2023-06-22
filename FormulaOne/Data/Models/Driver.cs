namespace FormulaOne.Data.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string DriverRef { get; set; }
        public int? Number { get; set; }
        public string? Code { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }
        public string Nationality { get; set; }
        public string Url { get; set; }

        public ICollection<Result> Results { get; set; }
        public ICollection<SprintResult> SprintResults { get; set; }
        public ICollection<LapTime> LapTimes { get; set; }
        public ICollection<PitStop> PitStops { get; set; }
        public ICollection<Qualifying> Qualifyings { get; set; }
        public ICollection<DriverStanding> DriverStandings { get; set; }
    }
}
