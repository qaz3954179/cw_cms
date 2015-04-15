using GMS.Web.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Site.Controllers
{
    public class ManagerController : AdminControllerBase
    {
        //
        // GET: /Site/Manager/

        public ActionResult Index()
        {
            return View();
        }

    }
}
