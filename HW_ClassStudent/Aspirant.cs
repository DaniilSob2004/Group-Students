using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_Address;


namespace HW_ClassStudent
{
    public class Aspirant : Student
    {
        private string dissertation;

        public Aspirant(string name, string surname, string dissertation) :
            this(name, surname, dissertation, new DateTime(), new Address()) { }

        public Aspirant(string name, string surname, string dissertation, DateTime birthDate, Address address, string phoneNumber = "") :
            base(name, surname, birthDate, address, phoneNumber)
        {
            Dissertation = dissertation;
        }

        public string Dissertation
        {
            get { return dissertation; }
            set
            {
                if (value.Length == 0) throw new Exception("Error dissertation value!");
                dissertation = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Dissertation: {Dissertation}\n";
        }
    }
}
