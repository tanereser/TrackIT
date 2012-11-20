using System;
using System.Web;
using System.IO;
using System.Web.Hosting;

namespace TrackIT.Models
{
    internal class DiskFileStore : IFileStore
    {
        private string _uploadsFolder = HostingEnvironment.MapPath("~/Content/Files");

        //public Guid SaveUploadedFile(HttpPostedFileBase fileBase)
        //{
        //    var identifier = Guid.NewGuid();
        //    fileBase.SaveAs(GetDiskLocation(identifier));
        //    return identifier;
        //}

        public string SaveUploadedFile(HttpPostedFileBase fileBase)
        {
            fileBase.SaveAs(GetDiskLocation(fileBase.FileName));
            return fileBase.FileName;
        }

        private string GetDiskLocation(string fileName)
        {
            return Path.Combine(_uploadsFolder, fileName);
        }
    }
}