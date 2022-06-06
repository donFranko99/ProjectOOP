using System;

namespace WaterRescueDBConversion
{
    public class Lifeguard
    {
        public int LifeguardID { get; set; }
        public string LifeguardName { get; set; }
        public string LifeguardSurname { get; set; }
        public char[] LifeguardPhoneNumber { get; set; }
        public int LifeguardRole { get; set; }
    }
    public class Report
    {
        public int InterventionID { get; set; }
        public DateOnly InterventionDate { get; set; }
        public TimeOnly InterventionTime { get; set; }
        public string InterventionReport { get; set; }
    }
    public class Intervention
    {
        public int InterventionID { get; set; }
        public int LifeguardID { get; set; }
        public DateOnly InterventionDate { get; set; }
        public int ResponseTime { get; set; }
    }
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
