using GMS.Site.Contract;
using GMS.Site.Contract.Model;
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
            SiteInfo siteInfo = this.SiteService.GetSiteInfo(1);

            return View(siteInfo);
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            int ID = 0;
            if (int.TryParse(form.Get("ID"), out ID))
            {
                ID = 1;
            }
            SiteInfo siteInfo = new SiteInfo();
            siteInfo.ID = ID;
            siteInfo.ICP = form.Get("ICP");
            siteInfo.Mobile = form.Get("Mobile");
            siteInfo.QQ = form.Get("QQ");
            siteInfo.Service1 = form.Get("Service1");
            siteInfo.Service2 = form.Get("Service2");
            siteInfo.QrCodeUrl = form.Get("QrCodeUrl");
            siteInfo.Phone = form.Get("Phone");
            siteInfo.Addr = form.Get("Addr");
            siteInfo.Email = form.Get("Email");
            siteInfo.LeftAdvert = form.Get("LeftAdvert");
            siteInfo.RightAdvert = form.Get("RightAdvert");

            this.SiteService.InsertOrUpdate(siteInfo);

            return RedirectToAction("Index");
        }

       
    }
}
