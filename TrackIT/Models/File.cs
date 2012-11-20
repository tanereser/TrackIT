using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackIT.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IssueId { get; set; }
        public DateTime UploadDate { get; set; }
    }
}