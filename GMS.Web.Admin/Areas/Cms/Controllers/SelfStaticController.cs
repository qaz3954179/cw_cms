using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.Cms.Contract;
using GMS.Account.Contract;
using GMS.Web.Admin.Common;
using GMS.Framework.Utility;

namespace GMS.Web.Admin.Areas.Cms.Controllers
{
     [Permission(EnumBusinessPermission.CmsManage_Channel)]
    public class SelfStaticController : AdminControllerBase
    {
        //
        // GET: /Cms/SelfStatic/

         public ActionResult IndexStatic(int id, ArticleRequest request)
        {
            Channel model = this.CmsService.GetChannel(id);
            if (request.ChannelId == 0) request.ChannelId = id;
            model.Articles = (System.Collections.Generic.List<Article>)this.CmsService.GetArticleList(request);
            return View( model);
        }
         public ActionResult EditArticle(int id)
         {
             var model = this.CmsService.GetArticle(id);

             var channelList = this.CmsService.GetChannelList(new ChannelRequest() { IsActive = true });
             this.ViewBag.ChannelId = new SelectList(channelList, "ID", "Name");
             this.ViewBag.Tags = this.CmsService.GetTagList(new TagRequest() { Top = 20, Orderby = Orderby.Hits });

             return View(model);
         }

         //
         // POST: /Cms/Article/Edit/5

         [HttpPost]
         [ValidateInput(false)]
         public ActionResult EditArticle(int id, FormCollection collection)
         {
             var model = this.CmsService.GetArticle(id);
             this.TryUpdateModel<Article>(model);

             this.CmsService.SaveArticle(model);

             return this.RefreshParent();
         }
    }
}
