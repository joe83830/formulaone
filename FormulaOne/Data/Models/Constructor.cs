namespace FormulaOne.Data.Models
{
    public class Constructor
    {
        public int ConstructorId { get; set; }
        public string ConstructorRef { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Url { get; set; }

        public ICollection<Qualifying> Qualifyings { get; set; }
        public ICollection<ConstructorResult> ConstructorResults { get; set; }
        public ICollection<ConstructorStanding> ConstructorStandings { get; set; }
        public ICollection<Result> Results { get; set; }
        public ICollection<SprintResult> SprintResults { get; set; }
    }
}
