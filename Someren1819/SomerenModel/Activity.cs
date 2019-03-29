using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Activity
    {
        public int activity_id { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
        public int numberofstudents { get; set; }
        public int numberofsupervisors { get; set; }
        public int supervisor1 { get; set; }
        public int supervisor2 { get; set; }

    }
}
