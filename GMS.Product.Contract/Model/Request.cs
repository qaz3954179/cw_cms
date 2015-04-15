using System;
using System.Collections.Generic;
using GMS.Framework.Contract;

namespace GMS.Product.Contract
{
    public class ProductTypeRequest:Request
    {
        public string TypeName { get; set; }
        public bool? IsActive { get; set; }
    }
    public class ProductItemRequest : Request
    {

        public string ItemName { get; set; }
        public int ProductTypeId { get; set; }
        public bool? IsActive { get; set; }
    }
}
