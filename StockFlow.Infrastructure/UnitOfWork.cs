using Microsoft.EntityFrameworkCore;
using StockFlow.Application.Repositories;
using StockFlow.Domain;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Infrastructure;

public class UnitOfWork(AppDbContext context) : IUnitOfWork {
    private readonly AppDbContext _db = context;

    public async Task BeginTransactionAsync() {
        await _db.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync() {
        await _db.SaveChangesAsync();
        await _db.Database.CommitTransactionAsync();
    }
}