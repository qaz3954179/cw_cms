using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMS.Product.Contract;
using GMS.Product.DAL;
using GMS.Framework.Utility;
using System.Data.Objects;
using GMS.Framework.Contract;
using EntityFramework.Extensions;
using GMS.Core.Cache;

namespace GMS.Product.BLL
{
    public class ProductService : IProductService
    {

        #region  ProductType
        public ProductType GetProductType(int id)
        {
            using (var dbContext = new ProductDbCntext())
            {
                return dbContext.Find<ProductType>(id);
            }
        }

        public System.Collections.Generic.IEnumerable<ProductType> GetProductTypeList(ProductTypeRequest request = null)
        {
            request = request ?? new ProductTypeRequest();
            using (var dbContext = new ProductDbCntext())
            {
                IQueryable<ProductType> productTypes = dbContext.ProductTypes;

                if (!string.IsNullOrEmpty(request.TypeName))
                    productTypes = productTypes.Where(u => u.TypeName.Contains(request.TypeName));

                if (request.IsActive != null)
                    productTypes = productTypes.Where(u => u.IsActive == request.IsActive);

                return productTypes.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveProductType(ProductType productType)
        {
            using (var dbContext = new ProductDbCntext())
            {
                if (productType.ID > 0)
                {
                    dbContext.Update<ProductType>(productType);
                }
                else
                {
                    dbContext.Insert<ProductType>(productType);
                }
            }
        }

        public void DeleteProductType(System.Collections.Generic.List<int> ids)
        {
            using (var dbContext = new ProductDbCntext())
            {
                dbContext.ProductTypes.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion

        #region ProductItem
        public ProductItem GetProductItem(int id)
        {
            using (var dbContext = new ProductDbCntext())
            {
                return dbContext.Find<ProductItem>(id);
            }
        }

        public IEnumerable<ProductItem> GetProductItemList(ProductItemRequest request = null)
        {
            request = request ?? new ProductItemRequest();
            using (var dbContext = new ProductDbCntext())
            {
                IQueryable<ProductItem> productItems = dbContext.ProductItems.Include("ProductType");

                if (!string.IsNullOrEmpty(request.ItemName))
                    productItems = productItems.Where(u => u.ItemName.Contains(request.ItemName));

                if (request.ProductTypeId > 0)
                    productItems = productItems.Where(u => u.ProductTypeId == request.ProductTypeId);

                if (request.IsActive != null)
                    productItems = productItems.Where(u => u.IsActive == request.IsActive);

                return productItems.OrderByDescending(u => u.ID).ToPagedList(request.PageIndex, request.PageSize);
            }
        }

        public void SaveProductItem(ProductItem productItem)
        {
            using (var dbContext = new ProductDbCntext())
            {
                if (productItem.ID > 0)
                {
                    dbContext.Update<ProductItem>(productItem);
                }
                else
                {
                    dbContext.Insert<ProductItem>(productItem);
                }
            }
        }

        public void DeleteProductItem(List<int> ids)
        {
            using (var dbContext = new ProductDbCntext())
            {
                dbContext.ProductItems.Where(u => ids.Contains(u.ID)).Delete();
            }
        }
        #endregion
    }
}
