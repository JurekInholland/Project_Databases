using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Teacher
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Number { get; set; } // LecturerNumber, e.g. 47198
        public int Supervisor { get; set; }

        //public String Speciality { get; set; }
    }
}
