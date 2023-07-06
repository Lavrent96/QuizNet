using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Stuffing
    {
        public int Id { get; set; }
        public string SealNumber { get; set; }
        public string TrackerNumber { get; set; }

        public int ShipmentId { get; set; }

    }
}
