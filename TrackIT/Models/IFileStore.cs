using System;
using System.Web;

namespace TrackIT.Models
{
    public interface IFileStore
    {
        string SaveUploadedFile(HttpPostedFileBase fileBase);
    }
}