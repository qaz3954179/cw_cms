using GMS.Framework.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GMS.Site.Contract.Model
{
    [Serializable]
    [Table("Site_Management")]
    public class SiteInfo : ModelBase
    {
        public string LogoUrl { get; set; }

        public string ICP { get; set; }

        public string Service1 { get; set; }

        public string Service2 { get; set; }

        public string QrCodeUrl { get; set; }

        public string Addr { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string QQ { get; set; }

        public string Email { get; set; }

        public string LeftAdvert { get; set; }

        public string RightAdvert { get; set; }
    }
}
