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
    [Permission(EnumBusinessPermission.ProductManage_ProductItem)]
    public class ProductItemController : AdminControllerBase
    {
        public ActionResult Index(ProductItemRequest request) {
            var typeList = this.ProductService.GetProductTypeList(new ProductTypeRequest() { IsActive = true });
            this.ViewBag.ProductTypeId = new SelectList(typeList, "ID", "TypeName");
            var result = this.ProductService.GetProductItemList(request);
            return View(result);
        }
        public ActionResult Create()
        {
            var typeList = this.ProductService.GetProductTypeList(new ProductTypeRequest() { IsActive = true });
            this.ViewBag.ProductTypeId = new SelectList(typeList, "ID", "TypeName");

            var model = new ProductItem() { IsActive = true };
            return View("Edit", model);
        }

        //
        // POST: /Cms/Article/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection collection)
        {
            var model = new ProductItem() ;
            this.TryUpdateModel<ProductItem>(model);

            this.ProductService.SaveProductItem(model);

            return this.RefreshParent();
        }

        //
        // GET: /Cms/Article/Edit/5

        public ActionResult Edit(int id)
        {
            var model = this.ProductService.GetProductItem(id);

            var typeList = this.ProductService.GetProductTypeList(new ProductTypeRequest() { IsActive = true });
            this.ViewBag.ProductTypeId = new SelectList(typeList, "ID", "TypeName");

            return View(model);
        }

        //
        // POST: /Cms/Article/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = this.ProductService.GetProductItem(id);
            this.TryUpdateModel<ProductItem>(model);

            this.ProductService.SaveProductItem(model);

            return this.RefreshParent();
        }

        // POST: /Cms/Article/Delete/5

        [HttpPost]
        public ActionResult Delete(List<int> ids)
        {
            this.ProductService.DeleteProductItem(ids);
            return RedirectToAction("Index");
        }
    }
}