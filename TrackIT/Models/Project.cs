using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackIT.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public DateTime StartDate { get; set; }
    }
}