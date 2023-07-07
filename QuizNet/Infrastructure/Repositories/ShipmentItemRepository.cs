using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ShipmentItemRepository : IShipmentItemRepository
    {
        private readonly AppDbContext _context;

        public ShipmentItemRepository(AppDbContext context)
        {
            _context = context;
        }

        /*GetAll_Correct Function:

        This function follows a best practice approach.
        If the id parameter is 0, indicating an invalid or missing value, it returns an empty collection of ShipmentItem using Enumerable.Empty<ShipmentItem>().
        When the id parameter is not 0, it retrieves all ShipmentItems from the _context where the ShipmentId matches the provided id.
        The function ensures that even if the id is 0, an empty result is returned instead of a null value.*/
        public IEnumerable<ShipmentItem> GetAll_Correct(int id)
        {
            if (id == 0)
            {
                return Enumerable.Empty<ShipmentItem>();
            }

            return _context.ShipmentItems.Where(e => e.ShipmentId == id);
        }

        /*GetAll_InCorrect Function:

         This function demonstrates a common mistake or bad practice.
         If the id parameter is 0, it returns null.
         When the id parameter is not 0, it retrieves all ShipmentItems from the _context where the ShipmentId matches the provided id.
         The problem with this approach is that it can potentially introduce null reference exceptions or unexpected behavior if the returned value is not properly checked by the caller.*/
        public IEnumerable<ShipmentItem> GetAll_InCorrect(int id)
        {
            if (id == 0)
            {
                return null;
            }

            return _context.ShipmentItems.Where(e => e.ShipmentId == id);
        }


        /*Insert_Correct Function:

        This function follows a best practice approach.
        It checks if the newItem parameter is null using newItem == null.
        If newItem is null, it throws an ArgumentNullException to indicate that the parameter cannot be null.
        It then retrieves the associated Shipment using the ShipmentId from the newItem using FindAsync.
        If the shipment is null, indicating no matching Shipment with the provided ShipmentId, it throws an ArgumentException with an appropriate error message.
        Finally, it adds the newItem to the _context.ShipmentItems, saves the changes to the database using SaveChangesAsync, and returns the newly inserted ShipmentItem.*/
        public async Task<ShipmentItem> Insert_Correct(ShipmentItem newItem)
        {
            if (newItem == null)
            {
                throw new ArgumentNullException(nameof(newItem), "The newItem parameter cannot be null.");
            }

            var shipment = await _context.Shipments.FindAsync(newItem.ShipmentId);
          
            if (shipment is null)
            {
                throw new ArgumentException("Invalid ShipmentId. No matching shipment found.", nameof(newItem));
            }

            _context.ShipmentItems.Add(newItem);
            await _context.SaveChangesAsync();

            return newItem;
        }

        /*Insert_InCorrect Function:

        This function represents a bad practice example.
        It does not perform any validation or null checking for the newItem parameter.
        It directly adds the newItem to the _context.ShipmentItems DbSet without any error handling or validation.
        It assumes that the input (newItem) will always be valid and does not handle any exceptions that may occur during the insertion.*/
        public async Task<ShipmentItem> Insert_InCorrect(ShipmentItem newItem)
        {
            _context.ShipmentItems.Add(newItem);
            await _context.SaveChangesAsync();

            return newItem;
        }

        /*Update_Correct Function:

        This function follows a best practice approach.
        It checks if the id parameter is less than 1, indicating an invalid ID. If so, it returns null.
        It retrieves the existing ShipmentItem from the _context.ShipmentItems DbSet using FindAsync(id).
        If the shipmentItemDb is null, indicating no record found with the provided ID, it returns null.
        It updates the properties of shipmentItemDb with the corresponding properties from the updatedItem.
        Finally, it saves the changes to the database using SaveChangesAsync() and returns the updated shipmentItemDb.*/
        public async Task<ShipmentItem> Update_Correct(int id, ShipmentItem updatedItem)
        {
            if (id < 1)
            {
                return null; // Invalid ID
            }

            var shipmentItemDb = await _context.ShipmentItems.FindAsync(id);
            if (shipmentItemDb is null)
            {
                return null; // No record found with the provided ID
            }

            shipmentItemDb.ArticleDescription = updatedItem.ArticleDescription;
            shipmentItemDb.ArticleCode = updatedItem.ArticleCode;
            shipmentItemDb.CommodityCode = updatedItem.CommodityCode;
            shipmentItemDb.Packages = updatedItem.Packages;
            shipmentItemDb.PackageType = updatedItem.PackageType;
            shipmentItemDb.Pieces = updatedItem.Pieces;
            shipmentItemDb.Volume = updatedItem.Volume;

            await _context.SaveChangesAsync();

            return shipmentItemDb;
        }

        /*Update_InCorrect Function:

        This function represents a bad practice example.
        It retrieves the existing ShipmentItem from the _context.ShipmentItems DbSet using Where and FirstOrDefaultAsync.
        It does not perform any validation or null checking for the id parameter.
        It assumes that a record will always be found with the provided ID.
        It updates the properties of shipmentItemDb with the corresponding properties from the updatedItem.
        Finally, it saves the changes to the database using SaveChangesAsync() and returns the updated shipmentItemDb.*/
        public async Task<ShipmentItem> Update_InCorrect(int id, ShipmentItem updatedItem)
        {
            var shipmentItemDb = await _context.ShipmentItems.Where(e => e.Id == id).FirstOrDefaultAsync();

            shipmentItemDb.ArticleDescription = updatedItem.ArticleDescription;
            shipmentItemDb.ArticleCode = updatedItem.ArticleCode;
            shipmentItemDb.CommodityCode = updatedItem.CommodityCode;
            shipmentItemDb.Packages = updatedItem.Packages;
            shipmentItemDb.PackageType = updatedItem.PackageType;
            shipmentItemDb.Pieces = updatedItem.Pieces;
            shipmentItemDb.Volume = updatedItem.Volume;

            await _context.SaveChangesAsync();

            return shipmentItemDb;
        }

        /*UpdateShipmentItemsByShipmentId_Correct Function:

        This function follows a best practice approach.
        It checks if the newCommodityCode parameter is null or empty using string.IsNullOrEmpty(newCommodityCode).
        If newCommodityCode is null or empty, it throws an ArgumentException to indicate that the parameter cannot be null or empty.
        It retrieves the associated Shipment using the shipmentId from the _context.Shipments DbSet using FindAsync.
        If the shipment is null, indicating no matching Shipment with the provided shipmentId, it throws an ArgumentException with an appropriate error message.
        It retrieves the ShipmentItems associated with the shipmentId from the _context.ShipmentItems DbSet using Where and ToListAsync.
        It iterates through each shipmentItem and updates its CommodityCode property to the specified newCommodityCode value.
        Finally, it saves the changes to the database using SaveChangesAsync and returns the number of affected records.*/
        public async Task<int> UpdateShipmentItemsByShipmentId_Correct(int shipmentId, string newCommodityCode)
        {
            if (string.IsNullOrEmpty(newCommodityCode))
            {
                throw new ArgumentException("The newCommodityCode parameter cannot be null or empty.");
            }

            var shipment = await _context.Shipments.FindAsync(shipmentId) ?? throw new ArgumentException("Invalid shipmentId. No matching shipment found.", nameof(shipmentId));
           
            var updateResult = await _context.ShipmentItems
                .Where(si => si.ShipmentId == shipmentId).ExecuteUpdateAsync(si => si.SetProperty(i => i.CommodityCode, newCommodityCode));

            return updateResult;
        }

        /*UpdateShipmentItemsByShipmentId_InCorrect Function:

        This function represents a bad practice example.
        It retrieves the ShipmentItems associated with the shipmentId from the _context.ShipmentItems DbSet using Where and ToList.
        It does not perform any validation or null checking for the newCommodityCode parameter.
        It assumes that the newCommodityCode will always have a valid value.
        It updates the CommodityCode property of each shipmentItem with the specified newCommodityCode value.
        Finally, it saves the changes to the database using SaveChangesAsync and returns the number of affected records.*/
        public async Task<int> UpdateShipmentItemsByShipmentId_InCorrect(int shipmentId, string newCommodityCode)
        {
            var shipmentItems = _context.ShipmentItems
                .Where(si => si.ShipmentId == shipmentId)
                .ToList();

            foreach (var shipmentItem in shipmentItems)
            {
                shipmentItem.CommodityCode = newCommodityCode;
            }

            return await _context.SaveChangesAsync();
        }
    }
}
