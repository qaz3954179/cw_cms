using GMS.Site.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Site.Contract
{
    public interface ISiteService
    {
        SiteInfo GetSiteInfo(int Id);

        void InsertOrUpdate(SiteInfo site);


        List<Advert> GetAdvertList();

        Advert GetAdvert(int ID);

        Advert SaveAdvert(Advert advert);
    }
}
