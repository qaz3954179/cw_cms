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
    /// <summary>
    /// 本控制器适用于 导航栏上的 服装配饰，数码电器....
    /// 每个栏目上有广告图片方法 
    /// </summary>
    [Permission(EnumBusinessPermission.CmsManage_Channel)]
    public class SelfNormalController : AdminControllerBase
    {
        #region Channel 
        public ActionResult IndexNormal(int id, ArticleRequest request)
        {
            Channel model = this.CmsService.GetChannel(id);
            if (request.ChannelId == 0) request.ChannelId = id;
            model.Articles = (System.Collections.Generic.List<Article>)this.CmsService.GetArticleList(request);
            return View("EditeNormal", model);
        }
        /// <summary>
        /// 此保存会刷新整个页面，所以一般不用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public ActionResult EditeNormal(int id, FormCollection collection)
        {
            Channel model = this.CmsService.GetChannel(id);
            this.TryUpdateModel<Channel>(model);
            this.CmsService.SaveChannel(model);
            model.Articles = (System.Collections.Generic.List<Article>)this.CmsService.GetArticleList(new ArticleRequest() { ChannelId = id });
            return View(model);
        }
         [HttpPost]
        public ActionResult AjaxSaveNormal(int id, string picUrl, string linkUrl, string titleName)
        {
            if (Request.IsAjaxRequest())
            {
                Channel model = this.CmsService.GetChannel(id);
                model.PicLinkUrl = linkUrl;
                model.CoverPicture = picUrl;
                if (model.Name != titleName) {
                    model.Name = titleName;
                    //
                    GMS.Core.Config.AdminMenuConfig menuConfig = GMS.Core.Config.CachedConfigContext.Current.AdminMenuConfig;
                    foreach (GMS.Core.Config.AdminMenuGroup group in menuConfig.AdminMenuGroups) {
                        if (String.Equals(group.Id, id.ToString())) {
                            group.Name = titleName; break;
                        }
                        foreach (GMS.Core.Config.AdminMenu menu in group.AdminMenuArray) {
                            if (String.Equals(menu.Id, id.ToString()))
                            {
                                menu.Name = titleName; break;
                            }
                        }
                    }
                    GMS.Core.Config.ConfigContext cc = new Core.Config.ConfigContext();
                    cc.Save(menuConfig);
                }
                this.TryUpdateModel<Channel>(model);
                this.CmsService.SaveChannel(model);
                return Json("保存成功！");
            }
            return Content("请不要用非法方法！");
        }

        protected Channel GetModelById(int id)
        {
            Channel model = this.CmsService.GetChannel(id);
            model.Articles = (System.Collections.Generic.List<Article>)this.CmsService.GetArticleList(new ArticleRequest() { ChannelId = id });
            return model;
        }

        #endregion


        #region Acticle
        public ActionResult CreateByChannel(int channelId)
        {
            var channelList = this.CmsService.GetChannelList(new ChannelRequest() { IsActive = true });
            this.ViewBag.ChannelId = new SelectList(channelList, "ID", "Name");
            this.ViewBag.Tags = this.CmsService.GetTagList(new TagRequest() { Top = 20, Orderby = Orderby.Hits });

            var model = new Article() { IsActive = true, ChannelId = channelId };
            return View("EditArticle", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateByChannel(FormCollection collection)
        {
            var model = new Article() { UserId = this.UserContext.LoginInfo.UserID, UserName = this.UserContext.LoginInfo.LoginName };
            this.TryUpdateModel<Article>(model);

            this.CmsService.SaveArticle(model);

            return this.RefreshParent();
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

        [HttpPost]
        public ActionResult DeleteArticles(int id, List<int> ids)
        {
            this.CmsService.DeleteArticle(ids);
            var model = this.GetModelById(id);
            return View("EditeNormal", model);
        }
       
        #endregion

    }
}
