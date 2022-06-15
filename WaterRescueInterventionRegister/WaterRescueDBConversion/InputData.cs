using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterRescueDBConversion
{
    public class InputData
    {
        public static void AddLifeguard(string name, string surname, string phoneNumber, string role)
        {
            if (phoneNumber.Length!=9)
            {
                throw new ArgumentException("Phone number has 9 digits");
            }
            if (name.Length>30 || surname.Length>30 || name==null || surname==null)
            {
                throw new ArgumentException("Wrong name or surname");
            }
            if (role=="Lifeguard")
            {
                role = "1";
            }
            if (role == "Head")
            {
                role = "2";
            }
            if (role == "Tech")
            {
                role = "3";
            }
            if (Int32.Parse(role) < 1 || Int32.Parse(role) > 3)
            {
                throw new ArgumentException("Roles take values from 1 to 3");
            }
            var db = new WaterRescueContext();
            int tmp = 1;
            tmp = DataFromDB.GetRoles().First().ID;
            foreach (Role r in DataFromDB.GetRoles())
            {
                if (Int32.Parse(role)==r.ID)
                {
                    tmp = r.ID;
                }
            }
            db.Add(new Lifeguard()
            {
                LifeguardName = name,
                LifeguardSurname = surname,
                LifeguardPhoneNumber = phoneNumber,
                RoleID = tmp
            });
            db.SaveChanges();
        }
        public static void EditLifeguard(int id, string field, string value)
        {
            bool success = true;
            if (value==null)
            {
                throw new ArgumentException("Empty argument");
            }
            using (var db = new WaterRescueContext())
            {
                switch (field)
                {
                    case "Name":
                        {
                            foreach (Lifeguard lg in db.Lifeguards)
                            {
                                if (id==lg.ID)
                                {
                                    lg.LifeguardName = value;
                                }
                            }
                            break;
                        }
                    case "Surname":
                        {
                            foreach (Lifeguard lg in db.Lifeguards)
                            {
                                if (id == lg.ID)
                                {
                                    lg.LifeguardSurname = value;
                                }
                            }
                            break;
                        }
                    case "Phone Number":
                        {
                            if (value.Length != 9)
                            {
                                throw new ArgumentException("Phone numbers have 9 digits.");
                            }
                            foreach (Lifeguard lg in db.Lifeguards)
                            {
                                if (id == lg.ID)
                                {
                                    lg.LifeguardPhoneNumber = value;
                                }
                            }
                            break;
                        }
                    case "Role ID":
                        {
                            foreach (Lifeguard lg in db.Lifeguards)
                            {
                                if (id == lg.ID)
                                {
                                    lg.RoleID = Int32.Parse(value);
                                }
                            }
                            break;
                        }

                    default:
                        {
                            success = false;
                            break;
                        }
                }
                if (success)
                {
                    db.SaveChanges();
                }
            }
        }
        public static void RemoveLifeguard(int id)
        {
            using(var db = new WaterRescueContext())
            {
                foreach (Lifeguard lg in db.Lifeguards)
                {
                    if (lg.ID == id)
                    {
                        db.Remove(lg);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
