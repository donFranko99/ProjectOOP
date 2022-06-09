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
            Role tmp = new Role();
            tmp.ID = Int32.Parse(role);
            db.Add(new Lifeguard()
            {
                LifeguardName = name,
                LifeguardSurname = surname,
                LifeguardPhoneNumber = phoneNumber,
                Role = tmp
            });
            db.SaveChanges();
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
