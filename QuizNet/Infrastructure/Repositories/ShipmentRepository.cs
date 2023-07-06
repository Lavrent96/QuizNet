using Domain;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly AppDbContext _context;

        public ShipmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Shipment> FindByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Shipment> FindByIdAsync_Correct(long shipmentId, params ShipmentModules[] includes)
        {
            if (shipmentId == 0)
                return null;

            var query = _context.Shipments.AsQueryable();

            foreach (ShipmentModules include in includes)
            {
                switch (include)
                {
                    case ShipmentModules.Containers:
                        query = query.Include(s => s.Containers);
                        break;
                    case ShipmentModules.Items:
                        query = query.Include(s => s.Items);
                        break;
                    case ShipmentModules.ShipmentRemarks:
                        query = query.Include(s => s.ShipmentRemarks);
                        break;
                    case ShipmentModules.Stuffing:
                        query = query.Include(s => s.Stuffings);
                        break;         
                    case ShipmentModules.Transports:
                        query = query.Include(s => s.Transports);
                        break;
                    default:
                        break;
                }
            }

            return await query.FirstOrDefaultAsync(s => s.Id == shipmentId);
        }

        public async Task<Shipment> FindByIdAsync_Incorrect1(long id)
        {
            if (id == 0)
                return null;

            var query = _context.Shipments
                .Include(x => x.Containers)
                .Include(x => x.Items)
                .AsQueryable();

            return await query.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Shipment> FindByIdAsync_Incorrect2(long id)
        {
            if (id == 0)
                return null;

            var query = _context.Shipments
                .Include(x => x.Transports)
                .Include(x => x.ShipmentRemarks)
                .AsQueryable();

            return await query.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Shipment> FindByIdAsync_Incorrect3(long id)
        {
            if (id == 0)
                return null;

            var query = _context.Shipments
                .Include(x => x.Stuffings)
                .Include(x => x.Containers)
                .Include(x => x.Items)
                .AsQueryable();

            return await query.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
