using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doctor.Con.Models
{
    public class Record
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime RecordId { get; set; }
        public string Comments { get; set; }
    }
}