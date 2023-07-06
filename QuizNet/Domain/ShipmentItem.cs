using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ShipmentItem
    {
        public int Id { get; set; }

        public string CommodityCode { get; set; }

        public string ArticleCode { get; set; }

        public string ArticleDescription { get; set; }

        public int? Pieces { get; set; }

        public int? Packages { get; set; }

        public string PackageType { get; set; }

        public decimal? Volume { get; set; }

        public int ShipmentId { get; set; }
    }
}
