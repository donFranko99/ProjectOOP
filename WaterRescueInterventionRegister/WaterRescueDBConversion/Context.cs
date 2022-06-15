using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterRescueDBConversion
{
    public class WaterRescueContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Lifeguard> Lifeguards { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<Report> Reports { get; set; }

        public string DBpath { get; }

        public WaterRescueContext()
        {
            var WaterRescueDB = Environment.SpecialFolder.LocalApplicationData;
            var Path = Environment.GetFolderPath(WaterRescueDB);
            DBpath = System.IO.Path.Join(Path, "Database\\WaterRescueDB.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            Console.WriteLine(DBpath);
            dbContextOptionsBuilder.UseSqlite($"DataSource ={DBpath}");
        }
    }
    public class Lifeguard
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string LifeguardName { get; set; }
        public string LifeguardSurname { get; set; }
        public string LifeguardPhoneNumber { get; set; }
        public Role Role { get; set; }
        public ICollection<Intervention> Interventions { get; set; }
    }
    public class Report
    {
        public int ID { get; set; }
        public DateTime InterventionTime { get; set; }
        public string InterventionReport { get; set; }
        public ICollection<Intervention> Interventions { get; set; }
    }
    public class Intervention
    {
        public int ID { get; set; }
        public int ReportID { get; set; }
        public int LifeguardID { get; set; }
        public int ResponseTime { get; set; }
        public Report Report { get; set; }
        public Lifeguard Lifeguard { get; set; }
    }
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public ICollection<Lifeguard> Lifeguards { get; set; }
    }
}
