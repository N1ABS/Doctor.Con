using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Doctor.Con.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(128)]
        public string ApplicationUserId { get; set; }
        public byte TargetReview { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public int? ClinicId { get; set; }
        public int? DoctorId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}