using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Doctor.Con.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Clinic> Clinics { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Profession> Professions { get; set; }

        public DbSet<Record> Records { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}