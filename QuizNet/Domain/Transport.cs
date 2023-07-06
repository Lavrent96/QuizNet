namespace Domain
{
    public class Transport
    {
        public int Id { get; set; }
        public string CarrierCode { get; set; }
        public TransportType Type { get; set; }

        public int ShipmentId { get; set; }

    }

    public enum TransportType
    {
        ORIGIN = 1,
        MAIN = 2,
        DESTINATION = 3
    }
}
