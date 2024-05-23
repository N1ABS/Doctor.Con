using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doctor.Con.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte TargetReview { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }
    }
}