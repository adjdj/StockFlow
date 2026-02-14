using Microsoft.EntityFrameworkCore;
using StockFlow.Application.Repositories;
using StockFlow.Domain;
using StockFlow.Application.ReadModel;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Infrastructure;

public class ReceiptDocumentRepository : IReceiptDocumentRepository {
    private readonly AppDbContext _db;

    public ReceiptDocumentRepository(AppDbContext db) {
        _db = db;
    }

    public async Task<bool> ExistsByNumberAsync(string number) {
        //await;
        return true;
    }

    public async Task AddAsync(ReceiptDocument document) {
        //await; 
    }
}