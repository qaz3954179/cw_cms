using System;
using System.Linq;
using GMS.Framework.Contract;
using System.Collections.Generic;
using GMS.Framework.Utility;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GMS.Product.Contract
{
    [Serializable]
    [Table("Product_Type")]
    public class ProductType : ModelBase
    {
        public ProductType() { }

        [StringLength(100)]
        [Required]
        public String TypeName { get; set; }
        [StringLength(300)]
        public String CoverPicture { get; set; }

        [StringLength(300)]
        public String Describe { get; set; }

        public bool IsActive { get; set; }
        [Required]
        public int Sort { get; set; }

        public virtual List<ProductItem> ProductItems { get; set; }
    }
}
