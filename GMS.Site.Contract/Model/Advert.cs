using GMS.Framework.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GMS.Site.Contract.Model
{
    [Serializable]
    [Table("Advert")]
    public class Advert : ModelBase
    {
        public String Name { get; set; }

        public String Link { get; set; }

        public String ImageUrl { get; set; }

        public Boolean IsDel { get; set; }
    }
}
