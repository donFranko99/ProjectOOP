﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WaterRescueDBConversion;

#nullable disable

namespace WaterRescueDBConversion.Migrations
{
    [DbContext(typeof(WaterRescueContext))]
    partial class WaterRescueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("WaterRescueDBConversion.Intervention", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LifeguardID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReportID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResponseTime")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("LifeguardID");

                    b.HasIndex("ReportID");

                    b.ToTable("Interventions");
                });

            modelBuilder.Entity("WaterRescueDBConversion.Lifeguard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LifeguardName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LifeguardPhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("LifeguardSurname")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RoleID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoletID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("Lifeguards");
                });

            modelBuilder.Entity("WaterRescueDBConversion.Report", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("InterventionReport")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InterventionTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("WaterRescueDBConversion.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleName")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WaterRescueDBConversion.Intervention", b =>
                {
                    b.HasOne("WaterRescueDBConversion.Lifeguard", "Lifeguard")
                        .WithMany("Interventions")
                        .HasForeignKey("LifeguardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WaterRescueDBConversion.Report", "Report")
                        .WithMany("Interventions")
                        .HasForeignKey("ReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lifeguard");

                    b.Navigation("Report");
                });

            modelBuilder.Entity("WaterRescueDBConversion.Lifeguard", b =>
                {
                    b.HasOne("WaterRescueDBConversion.Role", "Role")
                        .WithMany("Lifeguards")
                        .HasForeignKey("RoleID");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WaterRescueDBConversion.Lifeguard", b =>
                {
                    b.Navigation("Interventions");
                });

            modelBuilder.Entity("WaterRescueDBConversion.Report", b =>
                {
                    b.Navigation("Interventions");
                });

            modelBuilder.Entity("WaterRescueDBConversion.Role", b =>
                {
                    b.Navigation("Lifeguards");
                });
#pragma warning restore 612, 618
        }
    }
}
