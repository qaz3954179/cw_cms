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
    [Table("Product_Item")]
    public class ProductItem : ModelBase
    {
        public ProductItem() { }

        [StringLength(100)]
        [Required]
        public String ItemName { get; set; }

        [StringLength(300)]
        [Required]
        public String ItemUrl { get; set; }

        [StringLength(300)]
        [Required]
        public String CoverPicture { get; set; }

        [StringLength(300)]
        public String Describe { get; set; }

        public int ProductTypeId { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public int Sort { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
