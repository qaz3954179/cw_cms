using GMS.Site.Contract.Model;
using GMS.Web.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Site.Controllers
{
    public class AdvertController : AdminControllerBase
    {
        //
        // GET: /Site/Advert/

        public ActionResult Index()
        {
            List<Advert> list = this.SiteService.GetAdvertList();
            return View(list);
        }

        public ActionResult Edit(int ID)
        {
            Advert advert = new Advert();
            if (ID > 0)
                advert = this.SiteService.GetAdvert(ID);
            return View(advert);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            Advert advert = new Advert();
            advert.Name = form.Get("Name");
            advert.Link = form.Get("Link");
            advert.ImageUrl = form.Get("ImageUrl");
            advert.IsDel = false;

            advert = this.SiteService.SaveAdvert(advert);

            return RedirectToAction("Edit", "Manager", advert.ID);
        }

    }
}
