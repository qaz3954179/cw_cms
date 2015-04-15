using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Product.Contract;
using GMS.Account.Contract;
using GMS.Web.Admin.Common;
using GMS.Framework.Utility;

namespace GMS.Web.Admin.Areas.Product.Controllers
{
    [Permission(EnumBusinessPermission.ProductManage_ProductType)]
    public class ProductTypeController : AdminControllerBase
    {
        public ActionResult Index(ProductTypeRequest request)
        {
            var result = this.ProductService.GetProductTypeList(request);
            return View(result);
        }
        public ActionResult Create()
        {
            var model = new ProductType() { IsActive = true };
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var model = new ProductType();
            this.TryUpdateModel<ProductType>(model);

            this.ProductService.SaveProductType(model);

            return this.RefreshParent();
        }
        public ActionResult Edit(int id)
        {
            var model = this.ProductService.GetProductType(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProductService.GetProductType(id);
            this.TryUpdateModel<ProductType>(model);

            this.ProductService.SaveProductType(model);

            return this.RefreshParent();
        }


        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProductService.DeleteProductType(ids);
            return RedirectToAction("Index");
        }
    }
}