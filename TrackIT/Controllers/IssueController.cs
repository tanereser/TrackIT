using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace TrackIT.Controllers
{
    public class IssueController : BaseController
    {
        private TrackIT.Models.IFileStore _fileStore = new TrackIT.Models.DiskFileStore();

        //View a gerek var mı? 
        //Sonradan edit etmeye hakkı olmayan kullanıcıların sadece view etme gibi bir secenegi olabilir.
        public ActionResult View(int id)
        {
            var issue = db.Issues.Single(i => i.Id == id);
            var priorityTypes = db.PriorityTypes;
            ViewBag.PriorityTypes = priorityTypes;
            var statusTypes = db.StatusTypes;
            ViewBag.StatusTypes = statusTypes;

            return View(issue);
        }

        public ActionResult Create(int id) //Project Id
        {
            var projects = db.Projects;
            ViewBag.Projects = projects;
            var priorityTypes = db.PriorityTypes;
            ViewBag.PriorityTypes = priorityTypes;
            var statusTypes = db.StatusTypes;
            ViewBag.StatusTypes = statusTypes;
            var currentProject = db.Projects.Single(p => p.Id == id);
            ViewBag.CurrentProject = currentProject;

            return View(new Models.Issue() { ProjectId = id });
        }

        [HttpPost]
        public ActionResult Create(Models.Issue issue) //Project Id
        {
            issue.CreateDate = DateTime.Now;
            issue.Status = 1; //Default, Waiting
            db.Issues.Add(issue);
            db.SaveChanges();

            return RedirectToAction("View", "Project", new { id = issue.ProjectId });
        }

        public ActionResult Edit(int id)
        {
            var issue = db.Issues.Single(i => i.Id == id);
            var projects = db.Projects;
            ViewBag.Projects = projects;
            var priorityTypes = db.PriorityTypes;
            ViewBag.PriorityTypes = priorityTypes;
            var statusTypes = db.StatusTypes;
            ViewBag.StatusTypes = statusTypes;
            var currentProject = db.Projects.Single(p => p.Id == issue.ProjectId);
            ViewBag.CurrentProject = currentProject;
            var issueFileList = db.Files.Where(f => f.IssueId == id);
            ViewBag.IssueFileList = issueFileList;

            return View(issue);
        }

        [HttpPost]
        public ActionResult Edit(Models.Issue issue)
        {
            if (ModelState.IsValid)
            {
                issue.UpdateDate = DateTime.Now;
                if (issue.Status == 3 || issue.Status == 4) //Close yada Resolve
                    issue.CloseDate = DateTime.Now;
                db.Entry(issue).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("View", "Project", new { id = issue.ProjectId });
            }

            return RedirectToAction("Edit", new { id = issue.Id });
        }

        public string AsyncUpload(int id)
        {
            string fileName = string.Empty;
            //TODO: Upload edilen dosyayı, dbde issue ile ilişkilendir. Mapping kısaca.. Buradan dosya ismi dönüyor. (Yalnızca ismi. Path dönmüyor.)
            try
            {
                fileName = _fileStore.SaveUploadedFile(Request.Files[0]);
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                db.Files.Add(new Models.File() { IssueId = id, Name = fileName, UploadDate = DateTime.Now });
                db.SaveChanges();
                //Dosya ismini Kaydet
            }

            return fileName;
        }

        //public ActionResult AsyncUpload(int id)
        //{
        //    string fileName = string.Empty;
        //    IEnumerable<Models.File> issueFileList;

        //    //TODO: Upload edilen dosyayı, dbde issue ile ilişkilendir. Mapping kısaca.. Buradan dosya ismi dönüyor. (Yalnızca ismi. Path dönmüyor.)
        //    try
        //    {
        //        fileName = _fileStore.SaveUploadedFile(Request.Files[0]);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        db.Files.Add(new Models.File() { IssueId = id, Name = fileName, UploadDate = DateTime.Now });
        //        db.SaveChanges();
        //        issueFileList = db.Files.Where(f => f.IssueId == id);
        //        //Dosya ismini Kaydet
        //    }

        //    return PartialView("_IssueFileList", issueFileList);
        //}
    }
}
