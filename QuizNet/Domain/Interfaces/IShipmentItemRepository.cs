using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IShipmentItemRepository
    {
        IEnumerable<ShipmentItem> GetAll_Correct(int id);
        IEnumerable<ShipmentItem> GetAll_InCorrect(int id);

        Task<ShipmentItem> Insert_Correct(ShipmentItem newItem);
        Task<ShipmentItem> Insert_InCorrect(ShipmentItem newItem);

        Task<ShipmentItem> Update_Correct(int id, ShipmentItem item);
        Task<ShipmentItem> Update_InCorrect(int id, ShipmentItem item);

        Task<int> UpdateShipmentItemsByShipmentId_Correct(int shipmentId, string newCommodityCode);
        Task<int> UpdateShipmentItemsByShipmentId_InCorrect(int shipmentId, string newCommodityCode);

    }
}
