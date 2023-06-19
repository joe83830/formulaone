using System.ComponentModel.DataAnnotations;

namespace FormulaOne.Data.Models
{
    public class Race
    {
        [Key]
        public int RaceId { get; set; }
        public int Year { get; set; }
        public int Round { get; set; }
        public int CircuitId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Url { get; set; }
        public DateTime? Fp1Date { get; set; }
        public string Fp1Time { get; set; }
        public DateTime? Fp2Date { get; set; }
        public string Fp2Time { get; set; }
        public DateTime? Fp3Date { get; set; }
        public string Fp3Time { get; set; }
        public DateTime? QualiDate { get; set; }
        public string QualiTime { get; set; }
        public DateTime? SprintDate { get; set; }
        public string SprintTime { get; set; }

        public ICollection<Result> Results { get; set; }
        public ICollection<LapTime> LapTimes { get; set; }
        public ICollection<PitStop> PitStops { get; set; }
        public ICollection<Qualifying> Qualifyings { get; set; }
        public Circuit Circuit { get; set; }
        public ICollection<SprintResult> SprintResults { get; set; }
    }
}
