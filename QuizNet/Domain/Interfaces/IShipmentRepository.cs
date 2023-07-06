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
        Task<Shipment> FindByIdAsync_Incorrect1(long id);
        Task<Shipment> FindByIdAsync_Incorrect2(long id);
        Task<Shipment> FindByIdAsync_Incorrect3(long id);

    }
}
