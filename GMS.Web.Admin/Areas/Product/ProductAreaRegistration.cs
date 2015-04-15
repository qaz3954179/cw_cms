﻿using System.Web.Mvc;

namespace GMS.Web.Admin.Areas.Product
{
    public class ProductAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Product";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Product_default",
                "Product/{controller}/{action}/{id}",
                new { action = "Default", id = UrlParameter.Optional }
            );
        }
    }
}