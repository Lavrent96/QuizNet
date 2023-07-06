using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ShipmentRemark
    {
        public long Id { get; init; }
        public long? RemarkTemplateId { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedOn { get; init; }
        public long? CreatedById { get; init; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedById { get; set; }

        public int ShipmentId { get; set; }
    }
}
