using Microsoft.EntityFrameworkCore;
using StockFlow.Application.Repositories;
using StockFlow.Domain;
using StockFlow.Application.ReadModel;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Infrastructure;

public class ReceiptQueryRepository : IReceiptQueryRepository {
    private readonly AppDbContext _db;

    public ReceiptQueryRepository(AppDbContext context) {
        _db = context;
    }

    public async Task<List<ReceiptDocumentDto>> GetAllAsync() {
        var query =
            from d in _db.ReceiptDocuments.AsNoTracking()
            select new ReceiptDocumentDto {
                Id = d.Id,
                Number = d.Number,
                Date = d.Date,
                Items = (
                    from i in _db.ReceiptItems
                    join r in _db.Resources on i.ResourceId equals r.Id
                    join u in _db.Units on i.UnitId equals u.Id
                    where i.ReceiptDocumentId == d.Id
                    select new ReceiptItemDto {
                        Id = i.Id,
                        ResourceId = i.ResourceId,
                        ResourceName = r.Name.Value,
                        UnitId = i.UnitId,
                        UnitName = u.Name.Value,
                        Quantity = i.Quantity
                    }
                ).ToList()
            };

        return await query.ToListAsync();
    }

    public async Task<ReceiptDocumentDto?> GetByIdAsync(Guid id) {
        var query =
        from d in _db.ReceiptDocuments.AsNoTracking()
        where d.Id == id
        select new ReceiptDocumentDto {
            Id = d.Id,
            Number = d.Number,
            Date = d.Date,

            Items = (
                from i in _db.ReceiptItems
                join r in _db.Resources on i.ResourceId equals r.Id
                join u in _db.Units on i.UnitId equals u.Id
                where i.ReceiptDocumentId == d.Id
                select new ReceiptItemDto {
                    Id = i.Id,
                    ResourceId = i.ResourceId,
                    ResourceName = r.Name.Value,
                    UnitId = i.UnitId,
                    UnitName = u.Name.Value,
                    Quantity = i.Quantity
                }
            ).ToList()
        };

        return await query.FirstOrDefaultAsync();
    }
}