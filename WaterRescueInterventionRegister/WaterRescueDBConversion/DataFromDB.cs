using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace WaterRescueDBConversion
{
    public class DataFromDB
    {
        public static List<Lifeguard> GetLifeguards()
        {
            var lifeguards = new List<Lifeguard>();
            using (var db = new WaterRescueContext())
            {
                foreach (var lg in db.Lifeguards)
                {
                    lifeguards.Add(lg);
                }
                return lifeguards;
            }
        }
        public static List<Report> GetReports()
        {
            var reports = new List<Report>();
            using (var db = new WaterRescueContext())
            {
                foreach (var rep in db.Reports)
                {
                    reports.Add(rep);
                }
                return reports;
            }
        }
        public static List<Intervention> GetInterventions()
        {
            var interventions = new List<Intervention>();
            using (var db = new WaterRescueContext())
            {
                foreach (var inv in db.Interventions)
                {
                    interventions.Add(inv);
                }
                return interventions;
            }
        }
        public static List<Role> GetRoles()
        {
            var roles = new List<Role>();
            using (var db = new WaterRescueContext())
            {
                foreach (var role in db.Roles)
                {
                    roles.Add(role);
                }
                return roles;
            }
        }
    }
    /*
    public class Lifeguard
    {
        public int LifeguardID { get; set; }
        public string LifeguardName { get; set; }
        public string LifeguardSurname { get; set; }
        public char[] LifeguardPhoneNumber { get; set; }
        public Role Role { get; set; }
        public ICollection<Intervention> Interventions { get; set; }
    }
    public class Report
    {
        public int InterventionID { get; set; }
        public DateOnly InterventionDate { get; set; }
        public TimeOnly InterventionTime { get; set; }
        public string InterventionReport { get; set; }
        public ICollection<Intervention> Interventions { get; set; }
    }
    public class Intervention
    {
        public int ResponseTime { get; set; }
        public Report Report { get; set; }
        public Lifeguard Lifeguard { get; set; }
    }
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public ICollection<Lifeguard> Lifeguards { get; set; }
    }*/
}
