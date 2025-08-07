using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class JobsController : Controller
    {
        private JobPortalDbContext db = new JobPortalDbContext();

        // Allow anyone to see the list of jobs
        [AllowAnonymous]
        public ActionResult Index()
        {
            var jobs = db.Jobs.OrderByDescending(j => j.PostedDate).ToList();
            return View(jobs);
        }

        // Allow anyone to see job details
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // --- PROTECTED ACTIONS ---
        [Authorize(Roles = "Employer")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public ActionResult Create([Bind(Include = "Title,Description,Location,Salary,JobType,CompanyName,ContactEmail")] Job job)
        {
            if (ModelState.IsValid)
            {
                job.PostedDate = DateTime.Now;
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        [Authorize(Roles = "Employer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public ActionResult Edit([Bind(Include = "JobId,Title,Description,Location,Salary,JobType,CompanyName,ContactEmail,PostedDate")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        [Authorize(Roles = "Employer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer")]
        public ActionResult DeleteConfirmed(int id)
        {
            var applications = db.JobApplications.Where(a => a.JobId == id).ToList();
            if (applications.Any())
            {
                db.JobApplications.RemoveRange(applications);
            }
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
