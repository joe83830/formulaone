﻿// <auto-generated />
using System;
using FormulaOne.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormulaOne.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230621210300_ResultFastestLapNullables")]
    partial class ResultFastestLapNullables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FormulaOne.Data.Models.Circuit", b =>
                {
                    b.Property<int>("CircuitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CircuitId"));

                    b.Property<int?>("Alt")
                        .HasColumnType("integer");

                    b.Property<string>("CircuitRef")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Lat")
                        .HasColumnType("double precision");

                    b.Property<double>("Lng")
                        .HasColumnType("double precision");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CircuitId");

                    b.ToTable("Circuits");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Constructor", b =>
                {
                    b.Property<int>("ConstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ConstructorId"));

                    b.Property<string>("ConstructorRef")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ConstructorId");

                    b.ToTable("Constructors");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.ConstructorResult", b =>
                {
                    b.Property<int>("ConstructorResultsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ConstructorResultsId"));

                    b.Property<int>("ConstructorId")
                        .HasColumnType("integer");

                    b.Property<double>("Points")
                        .HasColumnType("double precision");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("ConstructorResultsId");

                    b.HasIndex("ConstructorId");

                    b.HasIndex("RaceId");

                    b.ToTable("ConstructorResults");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.ConstructorStanding", b =>
                {
                    b.Property<int>("ConstructorStandingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ConstructorStandingsId"));

                    b.Property<int>("ConstructorId")
                        .HasColumnType("integer");

                    b.Property<double>("Points")
                        .HasColumnType("double precision");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("PositionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.Property<int>("Wins")
                        .HasColumnType("integer");

                    b.HasKey("ConstructorStandingsId");

                    b.HasIndex("ConstructorId");

                    b.HasIndex("RaceId");

                    b.ToTable("ConstructorStandings");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DriverId"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DriverRef")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Forename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DriverId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.DriverStanding", b =>
                {
                    b.Property<int>("DriverStandingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DriverStandingsId"));

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<double>("Points")
                        .HasColumnType("double precision");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("PositionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.Property<int>("Wins")
                        .HasColumnType("integer");

                    b.HasKey("DriverStandingsId");

                    b.HasIndex("DriverId");

                    b.HasIndex("RaceId");

                    b.ToTable("DriverStandings");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.LapTime", b =>
                {
                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("Lap")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Milliseconds")
                        .HasColumnType("integer");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RaceId", "DriverId", "Lap");

                    b.HasIndex("DriverId");

                    b.ToTable("LapTimes");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.PitStop", b =>
                {
                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("Stop")
                        .HasColumnType("integer");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Lap")
                        .HasColumnType("integer");

                    b.Property<int>("Milliseconds")
                        .HasColumnType("integer");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RaceId", "DriverId", "Stop");

                    b.HasIndex("DriverId");

                    b.ToTable("PitStops");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Qualifying", b =>
                {
                    b.Property<int>("QualifyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QualifyId"));

                    b.Property<int>("ConstructorId")
                        .HasColumnType("integer");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("Q1")
                        .HasColumnType("text");

                    b.Property<string>("Q2")
                        .HasColumnType("text");

                    b.Property<string>("Q3")
                        .HasColumnType("text");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.HasKey("QualifyId");

                    b.HasIndex("ConstructorId");

                    b.HasIndex("DriverId");

                    b.HasIndex("RaceId");

                    b.ToTable("Qualifyings");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RaceId"));

                    b.Property<int>("CircuitId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Fp1Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Fp1Time")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Fp2Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Fp2Time")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Fp3Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Fp3Time")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("QualiDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("QualiTime")
                        .HasColumnType("text");

                    b.Property<int>("Round")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("SprintDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SprintTime")
                        .HasColumnType("text");

                    b.Property<string>("Time")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("RaceId");

                    b.HasIndex("CircuitId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ResultId"));

                    b.Property<int>("ConstructorId")
                        .HasColumnType("integer");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int?>("FastestLap")
                        .HasColumnType("integer");

                    b.Property<string>("FastestLapSpeed")
                        .HasColumnType("text");

                    b.Property<string>("FastestLapTime")
                        .HasColumnType("text");

                    b.Property<int>("Grid")
                        .HasColumnType("integer");

                    b.Property<int>("Laps")
                        .HasColumnType("integer");

                    b.Property<long?>("Milliseconds")
                        .HasColumnType("bigint");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<float>("Points")
                        .HasColumnType("real");

                    b.Property<int?>("Position")
                        .HasColumnType("integer");

                    b.Property<int>("PositionOrder")
                        .HasColumnType("integer");

                    b.Property<string>("PositionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.Property<int?>("Rank")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("Time")
                        .HasColumnType("text");

                    b.HasKey("ResultId");

                    b.HasIndex("ConstructorId");

                    b.HasIndex("DriverId");

                    b.HasIndex("RaceId");

                    b.HasIndex("StatusId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Season", b =>
                {
                    b.Property<int>("Year")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Year"));

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Year");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.SprintResult", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ResultId"));

                    b.Property<int>("ConstructorId")
                        .HasColumnType("integer");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("FastestLap")
                        .HasColumnType("integer");

                    b.Property<string>("FastestLapTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Grid")
                        .HasColumnType("integer");

                    b.Property<int>("Laps")
                        .HasColumnType("integer");

                    b.Property<long?>("Milliseconds")
                        .HasColumnType("bigint");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<int>("PositionOrder")
                        .HasColumnType("integer");

                    b.Property<string>("PositionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ResultId");

                    b.HasIndex("ConstructorId");

                    b.HasIndex("DriverId");

                    b.HasIndex("RaceId");

                    b.HasIndex("StatusId");

                    b.ToTable("SprintResults");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.ConstructorResult", b =>
                {
                    b.HasOne("FormulaOne.Data.Models.Constructor", "Constructor")
                        .WithMany("ConstructorResults")
                        .HasForeignKey("ConstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Constructor");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.ConstructorStanding", b =>
                {
                    b.HasOne("FormulaOne.Data.Models.Constructor", "Constructor")
                        .WithMany("ConstructorStandings")
                        .HasForeignKey("ConstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Constructor");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.DriverStanding", b =>
                {
                    b.HasOne("FormulaOne.Data.Models.Driver", "Driver")
                        .WithMany("DriverStandings")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.LapTime", b =>
                {
                    b.HasOne("FormulaOne.Data.Models.Driver", "Driver")
                        .WithMany("LapTimes")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Race", "Race")
                        .WithMany("LapTimes")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.PitStop", b =>
                {
                    b.HasOne("FormulaOne.Data.Models.Driver", "Driver")
                        .WithMany("PitStops")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Race", "Race")
                        .WithMany("PitStops")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Qualifying", b =>
                {
                    b.HasOne("FormulaOne.Data.Models.Constructor", "Constructor")
                        .WithMany("Qualifyings")
                        .HasForeignKey("ConstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Driver", "Driver")
                        .WithMany("Qualifyings")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Race", "Race")
                        .WithMany("Qualifyings")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Constructor");

                    b.Navigation("Driver");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Race", b =>
                {
                    b.HasOne("FormulaOne.Data.Models.Circuit", "Circuit")
                        .WithMany("Races")
                        .HasForeignKey("CircuitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Circuit");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Result", b =>
                {
                    b.HasOne("FormulaOne.Data.Models.Constructor", "Constructor")
                        .WithMany("Results")
                        .HasForeignKey("ConstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Driver", "Driver")
                        .WithMany("Results")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Race", "Race")
                        .WithMany("Results")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Constructor");

                    b.Navigation("Driver");

                    b.Navigation("Race");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.SprintResult", b =>
                {
                    b.HasOne("FormulaOne.Data.Models.Constructor", "Constructor")
                        .WithMany("SprintResults")
                        .HasForeignKey("ConstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Driver", "Driver")
                        .WithMany("SprintResults")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Race", "Race")
                        .WithMany("SprintResults")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormulaOne.Data.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Constructor");

                    b.Navigation("Driver");

                    b.Navigation("Race");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Circuit", b =>
                {
                    b.Navigation("Races");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Constructor", b =>
                {
                    b.Navigation("ConstructorResults");

                    b.Navigation("ConstructorStandings");

                    b.Navigation("Qualifyings");

                    b.Navigation("Results");

                    b.Navigation("SprintResults");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Driver", b =>
                {
                    b.Navigation("DriverStandings");

                    b.Navigation("LapTimes");

                    b.Navigation("PitStops");

                    b.Navigation("Qualifyings");

                    b.Navigation("Results");

                    b.Navigation("SprintResults");
                });

            modelBuilder.Entity("FormulaOne.Data.Models.Race", b =>
                {
                    b.Navigation("LapTimes");

                    b.Navigation("PitStops");

                    b.Navigation("Qualifyings");

                    b.Navigation("Results");

                    b.Navigation("SprintResults");
                });
#pragma warning restore 612, 618
        }
    }
}
