using System;
using GMS.Framework.DAL;
using GMS.Core.Config;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using GMS.Product.Contract;
using GMS.Core.Log;


namespace GMS.Product.DAL
{
    public class ProductDbCntext : DbContextBase
    {
        public ProductDbCntext()
            : base(CachedConfigContext.Current.DaoConfig.Product, new LogDbContext())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProductDbCntext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
    }
}
