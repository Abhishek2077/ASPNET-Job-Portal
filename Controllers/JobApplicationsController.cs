using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPortal.Models;

namespace JobPortal.Controllers
{
    public class JobApplicationsController : Controller
    {
        private JobPortalDbContext db = new JobPortalDbContext();

        // This action is now protected. Only users in the "Job Seeker" role can access it.
        [Authorize(Roles = "Job Seeker")]
        public ActionResult Create(int jobId)
        {
            var job = db.Jobs.Find(jobId);
            if (job == null)
            {
                return HttpNotFound();
            }
            var application = new JobApplication { JobId = jobId };
            ViewBag.JobTitle = job.Title;
            return View(application);
        }

        // This action is also protected for "Job Seekers".
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Job Seeker")]
        public ActionResult Create(JobApplication jobApplication, HttpPostedFileBase resumeFile)
        {
            ViewBag.JobTitle = db.Jobs.Find(jobApplication.JobId)?.Title ?? "Job Application";
            if (ModelState.IsValid)
            {
                if (resumeFile != null && resumeFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(resumeFile.FileName);
                    var extension = Path.GetExtension(resumeFile.FileName);
                    fileName = $"{fileName}-{Guid.NewGuid()}{extension}";
                    var path = Path.Combine(Server.MapPath("~/Uploads/Resumes"), fileName);
                    Directory.CreateDirectory(Server.MapPath("~/Uploads/Resumes"));
                    resumeFile.SaveAs(path);
                    jobApplication.ResumeFileName = fileName;
                }
                jobApplication.AppliedDate = DateTime.Now;
                db.JobApplications.Add(jobApplication);
                db.SaveChanges();
                return RedirectToAction("ApplicationSubmitted");
            }
            return View(jobApplication);
        }

        // The confirmation page can be seen by anyone who was just redirected.
        [AllowAnonymous]
        public ActionResult ApplicationSubmitted()
        {
            return View();
        }
    }
}
