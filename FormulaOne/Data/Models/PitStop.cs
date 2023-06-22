using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace FormulaOne.Data.Models
{
    public class PitStop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PitstopId { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public int Stop { get; set; }
        public int Lap { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public int Milliseconds { get; set; }

        public Race Race { get; set; }
        public Driver Driver { get; set; }
    }
}
