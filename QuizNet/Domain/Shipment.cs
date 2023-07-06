namespace Domain
{
    public class Shipment
    {
        public int Id { get; set; }
        public string CargooReference { get; set; }

        public string ServiceProviderName { get; set; }

        public List<ShipmentItem> Items { get; set; }
        public List<ShipmentContainer> Containers { get; set; }

        public List<Transport> Transports { get; set; }
        public List<ShipmentRemark> ShipmentRemarks { get; set; }
        public List<Stuffing> Stuffings { get; set; }
    }
}