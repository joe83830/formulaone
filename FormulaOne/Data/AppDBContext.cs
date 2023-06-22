using FormulaOne.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Circuit> Circuits { get; set; }
        public DbSet<ConstructorResult> ConstructorResults { get; set; }
        public DbSet<ConstructorStanding> ConstructorStandings { get; set; }
        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<DriverStanding> DriverStandings { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<LapTime> LapTimes { get; set; }
        public DbSet<PitStop> PitStops { get; set; }
        public DbSet<Qualifying> Qualifyings { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SprintResult> SprintResults { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Circuit
            modelBuilder.Entity<Circuit>().HasKey(c => c.CircuitId);

            // ConstructorResult
            modelBuilder.Entity<ConstructorResult>().HasKey(cr => cr.ConstructorResultsId);
            modelBuilder.Entity<ConstructorResult>().HasOne(cr => cr.Race).WithMany().HasForeignKey(cr => cr.RaceId);
            modelBuilder.Entity<ConstructorResult>().HasOne(cr => cr.Constructor).WithMany(c => c.ConstructorResults).HasForeignKey(cr => cr.ConstructorId);

            // ConstructorStanding
            modelBuilder.Entity<ConstructorStanding>().HasKey(cs => cs.ConstructorStandingsId);
            modelBuilder.Entity<ConstructorStanding>().HasOne(cs => cs.Race).WithMany().HasForeignKey(cs => cs.RaceId);
            modelBuilder.Entity<ConstructorStanding>().HasOne(cs => cs.Constructor).WithMany(c => c.ConstructorStandings).HasForeignKey(cs => cs.ConstructorId);

            // Constructor
            modelBuilder.Entity<Constructor>().HasKey(c => c.ConstructorId);

            // DriverStanding
            modelBuilder.Entity<DriverStanding>().HasKey(ds => ds.DriverStandingsId);
            modelBuilder.Entity<DriverStanding>().HasOne(ds => ds.Race).WithMany().HasForeignKey(ds => ds.RaceId);
            modelBuilder.Entity<DriverStanding>().HasOne(ds => ds.Driver).WithMany(d => d.DriverStandings).HasForeignKey(ds => ds.DriverId);

            // Driver
            modelBuilder.Entity<Driver>().HasKey(d => d.DriverId);

            // LapTime
            modelBuilder.Entity<LapTime>().HasKey(lt => lt.LapTimeId);
            modelBuilder.Entity<LapTime>().HasOne(lt => lt.Race).WithMany(r => r.LapTimes).HasForeignKey(lt => lt.RaceId);
            modelBuilder.Entity<LapTime>().HasOne(lt => lt.Driver).WithMany(d => d.LapTimes).HasForeignKey(lt => lt.DriverId);

            // PitStop
            modelBuilder.Entity<PitStop>().HasKey(ps => ps.PitstopId);
            modelBuilder.Entity<PitStop>().HasOne(ps => ps.Race).WithMany(r => r.PitStops).HasForeignKey(ps => ps.RaceId);
            modelBuilder.Entity<PitStop>().HasOne(ps => ps.Driver).WithMany(d => d.PitStops).HasForeignKey(ps => ps.DriverId);

            // Qualifying
            modelBuilder.Entity<Qualifying>().HasKey(q => q.QualifyId);
            modelBuilder.Entity<Qualifying>().HasOne(q => q.Race).WithMany(r => r.Qualifyings).HasForeignKey(q => q.RaceId);
            modelBuilder.Entity<Qualifying>().HasOne(q => q.Driver).WithMany(d => d.Qualifyings).HasForeignKey(q => q.DriverId);
            modelBuilder.Entity<Qualifying>().HasOne(q => q.Constructor).WithMany(c => c.Qualifyings).HasForeignKey(q => q.ConstructorId);

            // Race
            modelBuilder.Entity<Race>().HasKey(r => r.RaceId);
            modelBuilder.Entity<Race>().HasOne(r => r.Circuit).WithMany(c => c.Races).HasForeignKey(r => r.CircuitId);

            // Result
            modelBuilder.Entity<Result>().HasKey(r => r.ResultId);
            modelBuilder.Entity<Result>().HasOne(r => r.Race).WithMany(ra => ra.Results).HasForeignKey(r => r.RaceId);
            modelBuilder.Entity<Result>().HasOne(r => r.Driver).WithMany(d => d.Results).HasForeignKey(r => r.DriverId);
            modelBuilder.Entity<Result>().HasOne(r => r.Constructor).WithMany(c => c.Results).HasForeignKey(r => r.ConstructorId);
            modelBuilder.Entity<Result>().HasOne(r => r.Status).WithMany().HasForeignKey(r => r.StatusId);

            // Season
            modelBuilder.Entity<Season>().HasKey(s => s.Year);

            // SprintResult
            modelBuilder.Entity<SprintResult>().HasKey(sr => sr.ResultId);
            modelBuilder.Entity<SprintResult>().HasOne(sr => sr.Race).WithMany(r => r.SprintResults).HasForeignKey(sr => sr.RaceId);
            modelBuilder.Entity<SprintResult>().HasOne(sr => sr.Driver).WithMany(d => d.SprintResults).HasForeignKey(sr => sr.DriverId);
            modelBuilder.Entity<SprintResult>().HasOne(sr => sr.Constructor).WithMany(c => c.SprintResults).HasForeignKey(sr => sr.ConstructorId);

            // Status
            modelBuilder.Entity<Status>().HasKey(s => s.StatusId);
        }
    }

}
