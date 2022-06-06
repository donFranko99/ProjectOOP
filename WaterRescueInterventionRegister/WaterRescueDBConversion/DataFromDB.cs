using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WaterRescueDBConversion
{
    public class Lifeguard
    {
        public int LifeguardID { get; set; }
        public string LifeguardName { get; set; }
        public string LifeguardSurname { get; set; }
        public char[] LifeguardPhoneNumber { get; set; }
        public int LifeguardRole { get; set; }
        public virtual Intervention Intervention { get; set; }
        public virtual Role Role { get; set; }
        //public virtual ICollection<Role> Roles { get; private set; } = new ObservableCollection<Role>();
    }
    public class Report
    {
        public int InterventionID { get; set; }
        public DateOnly InterventionDate { get; set; }
        public TimeOnly InterventionTime { get; set; }
        public string InterventionReport { get; set; }
        public virtual ICollection<Intervention> Interventions { get; private set; } = new ObservableCollection<Intervention>();
    }
    public class Intervention
    {
        public int InterventionID { get; set; }
        public int LifeguardID { get; set; }
        public DateOnly InterventionDate { get; set; }
        public int ResponseTime { get; set; }
        public virtual Lifeguard Lifeguard { get; set; }
        public virtual Report Report { get; set; }
    }
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
