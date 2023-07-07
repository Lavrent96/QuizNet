using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IShipmentRepository
    {
        Task<Shipment> FindByIdAsync(long id);
        Task<Shipment> FindByIdAsync_Correct(long shipmentId, params ShipmentModules[] includes);
        Task<Shipment> FindByIdAsync_Containers(long id);
        Task<Shipment> FindByIdAsync_Transports(long id);
        Task<Shipment> FindByIdAsync_Items(long id);

    }
}
