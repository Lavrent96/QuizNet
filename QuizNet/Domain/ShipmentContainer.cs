using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ShipmentContainer
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string OriginalType { get; set; }
        public string Number { get; set; }

        public int ShipmentId { get; set; }

    }
}
