using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Doctor.Con.Models;

namespace Doctor.Con.Controllers
{
    public class DoctorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctors
        public async Task<ActionResult> Index()
        {
            var doctors = db.Doctors.Include(d => d.Clinic).Include(d => d.Profession);
            return View(await doctors.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            ViewBag.ClinicId = new SelectList(db.Clinics, "Id", "Name");
            ViewBag.ProfessionId = new SelectList(db.Professions, "Id", "Title");
            return View();
        }

        // POST: Doctors/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Phone,ProfessionId,ClinicId,Rating")] Models.Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClinicId = new SelectList(db.Clinics, "Id", "Name", doctor.ClinicId);
            ViewBag.ProfessionId = new SelectList(db.Professions, "Id", "Title", doctor.ProfessionId);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Doctor doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClinicId = new SelectList(db.Clinics, "Id", "Name", doctor.ClinicId);
            ViewBag.ProfessionId = new SelectList(db.Professions, "Id", "Title", doctor.ProfessionId);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Phone,ProfessionId,ClinicId,Rating")] Models.Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClinicId = new SelectList(db.Clinics, "Id", "Name", doctor.ClinicId);
            ViewBag.ProfessionId = new SelectList(db.Professions, "Id", "Title", doctor.ProfessionId);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Doctor doctor = await db.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Models.Doctor doctor = await db.Doctors.FindAsync(id);
            db.Doctors.Remove(doctor);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
