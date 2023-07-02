namespace FormulaOne.Data.DTOs
{
    public class DriverDTO
    {
        public string driverRef { get; set; }
        public int? number { get; set; }
        public string? code { get; set; }
        public string forename { get; set; }
        public string surname { get; set; }
        public DateTime dob { get; set; }
        public string nationality { get; set; }
    }
}
