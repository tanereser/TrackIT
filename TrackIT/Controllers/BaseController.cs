using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrackIT.Controllers
{
    public class BaseController : Controller
    {
        public Models.TrackITDb db = new Models.TrackITDb();
    }
}
