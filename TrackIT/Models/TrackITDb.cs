using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TrackIT.Models
{
    public class TrackITDb : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<PriorityType> PriorityTypes { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }
        public DbSet<File> Files { get; set; }
    }
}