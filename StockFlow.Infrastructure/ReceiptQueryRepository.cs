using Microsoft.EntityFrameworkCore;
using StockFlow.Application.Repositories;
using StockFlow.Domain;
using StockFlow.Application.ReadModel;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Infrastructure;

public class ReceiptQueryRepository : IReceiptQueryRepository {
    private readonly AppDbContext _context;

    public ReceiptQueryRepository(AppDbContext context) {
        _context = context;
    }

    public async Task<ReceiptDocumentDto?> GetByIdAsync(Guid id) {
        var query =
        from d in _context.ReceiptDocuments.AsNoTracking()
        where d.Id == id
        select new ReceiptDocumentDto {
            Id = d.Id,
            Number = d.Number,
            Date = d.Date,

            Items = (
                from i in _context.ReceiptItems
                join r in _context.Resources on i.ResourceId equals r.Id
                join u in _context.Units on i.UnitId equals u.Id
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