using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrackIT.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Summary { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int Priority { get; set; } //1-Low, 2-Normal, 3-High, 4-Very High
        public int Status { get; set; } //1-Waiting, 2-Open, 3-In Progress, 4-Closed, 5-Resolved
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CloseDate { get; set; }
    }
}