using GMS.Framework.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GMS.Account.Contract.Model
{
    [Auditable]
    [Table("Menu")]
    public class Menu: ModelBase
    {
        public Menu()
        {
            this.Name = "";
            this.Uri = "#";
        }
        [Required(ErrorMessage = "菜单名不能为空")]
        public string Name { get; set; }

        [Required(ErrorMessage = "菜单路径不能为空")]
        public string Uri { get; set; }

        public int PXH { get; set; }
    }
}
