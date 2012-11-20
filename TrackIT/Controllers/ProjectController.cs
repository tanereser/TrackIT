using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrackIT.Controllers
{
    public class ProjectController : BaseController
    {
        //
        // GET: /Project/

        public ActionResult View(int id, int? status)
        {
            var project = db.Projects.Single(p => p.Id == id);
            ViewBag.Project = project;
            var issues = db.Issues.Where(i => i.ProjectId == id && (status == null || i.Status == status));
            ViewBag.Issues = issues;
            var priorityTypes = db.PriorityTypes;
            ViewBag.PriorityTypes = priorityTypes;
            var statusTypes = db.StatusTypes;
            ViewBag.StatusTypes = statusTypes;
            ViewBag.CurrentStatus = status;

            return View(project);
        }

        //public ActionResult ViewIssues(int id, int? status)
        //{
        //    var project = db.Projects.Single(p => p.Id == id);
        //    var issues = db.Issues.Where(i => i.ProjectId == id && status == null || i.Status == status);

        //    return View(project);
        //}

        public ActionResult Create()
        {
            return View(new Models.Project());
        }

        [HttpPost]
        public ActionResult Create(Models.Project newProject)
        {
            newProject.StartDate = DateTime.Now;
            db.Projects.Add(newProject);
            db.SaveChanges();

            return RedirectToAction("View", "Project", new { id = newProject.Id });
        }

        public ActionResult Edit(int id)
        {
            var project = db.Projects.Single(p => p.Id == id);

            return View(project);
        }

        [HttpPost]
        public ActionResult Edit(Models.Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = System.Data.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Edit", "Project", new { id = project.Id });
        }
    }
}
