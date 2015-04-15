using GMS.Site.Contract;
using GMS.Site.Contract.Model;
using GMS.Site.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GMS.Site.BLL
{
    public class SiteService : ISiteService
    {
        public SiteInfo GetSiteInfo(int Id)
        {
            SiteInfo site = null;
            using (var dbContext = new SiteDbContext())
            {
                site = dbContext.SiteInformation.First(c => c.ID == 1);
            }
            return site;
        }


        public void InsertOrUpdate(SiteInfo site)
        {
            using (var dbContext = new SiteDbContext())
            {
                if (site.ID > 0)
                {
                    dbContext.Update<SiteInfo>(site);
                }
                else
                {

                    dbContext.Insert<SiteInfo>(site);
                }

                dbContext.SaveChanges();
            }
        }


        public List<Advert> GetAdvertList()
        {
            using (var dbContext = new SiteDbContext())
            {
                return dbContext.AdvertList.Where(c => c.IsDel == false).ToList();
            }
        }


        public Advert GetAdvert(int ID)
        {
            using (var dbContext = new SiteDbContext())
            {
                return dbContext.AdvertList.FirstOrDefault(c => c.ID == ID);
            }
        }


        public Advert SaveAdvert(Advert advert)
        {
            using (var dbContext = new SiteDbContext())
            {
                if (advert.ID > 0)
                {
                    advert = dbContext.Update<Advert>(advert);
                }
                else
                {
                    advert = dbContext.Insert<Advert>(advert);
                }
                dbContext.SaveChanges();
            }

            return advert;
        }
    }
}
