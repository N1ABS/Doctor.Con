using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doctor.Con.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int ProfessionId { get; set; }
        public int ClinicId { get; set; }
        public double Rating { get; set; }

        public virtual Profession Profession { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}