using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TrackIT
{
    public static class Utility
    {
        public static string ResolveFileExtension(string fileName)
        {
            var fileExtension = fileName.Substring(fileName.LastIndexOf(".") + 1, fileName.Length - fileName.LastIndexOf(".") - 1);
            string fileImage = string.Empty;
            switch (fileExtension)
            {
                case "doc":
                    fileImage = "/images/arzo_word.png";
                    break;
                case "docx":
                    fileImage = "/images/arzo_word.png";
                    break;
                case "xls":
                    fileImage = "/images/arzo_excel.png";
                    break;
                case "xlsx":
                    fileImage = "/images/arzo_excel.png";
                    break;
                case "zip":
                    fileImage = "/images/zip_file.png";
                    break;
                case "pdf":
                    fileImage = "/images/arzo_pdf.png";
                    break;
                case "rar":
                    fileImage = "/images/arzo_rar.png";
                    break;
                case "jpg":
                    fileImage = "/images/image.png";
                    break;
                case "jpeg":
                    fileImage = "/images/image.png";
                    break;
                case "gif":
                    fileImage = "/images/image.png";
                    break;
                case "png":
                    fileImage = "/images/image.png";
                    break;
                default:
                    fileImage = "/images/file.png";
                    break;
            }
            return fileImage;
        }
    }
}