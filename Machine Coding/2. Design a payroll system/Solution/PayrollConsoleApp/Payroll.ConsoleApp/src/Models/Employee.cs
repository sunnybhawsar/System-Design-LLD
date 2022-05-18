using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ConsoleApp.src.Models
{
    public class Employee
    {
        public Int32? rec_id { get; set; }
        public Int32? emp_id { get; set; }
        public DateTime? date { get; set; }
        public string time_in { get; set; }
        public string time_out { get; set; }
        public Decimal? total_hours { get; set; }
        public Int32? weekday { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string designation { get; set; }
        public string department { get; set; }
        public string calculate { get; set; }
        public Decimal? basic_salary { get; set; }
        public Decimal? per_day_salary { get; set; }
    }
}
