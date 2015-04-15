using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMS.Product.Contract
{
    public interface IProductService
    {

        ProductItem GetProductItem(int id);
        IEnumerable<ProductItem> GetProductItemList(ProductItemRequest request = null);
        void SaveProductItem(ProductItem productItem);
        void DeleteProductItem(List<int> ids);

        ProductType GetProductType(int id);
        IEnumerable<ProductType> GetProductTypeList(ProductTypeRequest request = null);
        void SaveProductType(ProductType productType);
        void DeleteProductType(List<int> ids);
    }
}
