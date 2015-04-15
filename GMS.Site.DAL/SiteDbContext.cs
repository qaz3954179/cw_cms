using GMS.Core.Config;
using GMS.Core.Log;
using GMS.Framework.DAL;
using GMS.Site.Contract.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace GMS.Site.DAL
{
    public class SiteDbContext : DbContextBase
    {
        public SiteDbContext()
            : base(CachedConfigContext.Current.DaoConfig.Site, new LogDbContext())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SiteDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SiteInfo> SiteInformation { get; set; }

        public DbSet<Advert> AdvertList { get; set; }

    }
}
