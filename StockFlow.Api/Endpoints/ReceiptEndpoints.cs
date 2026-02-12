/*!
 * @file BalanceEndpoints.cs
 * @brief Маршруты связанные с Балансом
 * @author -
 * @copyright -
 * @details
 *
 */
using Microsoft.EntityFrameworkCore;
using StockFlow.Application.Contracts;
using StockFlow.Application.UseCases;
using StockFlow.Infrastructure;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Api.Endpoints;

public static class ReceiptEndpoints {
    public static IEndpointRouteBuilder MapReceipts(this IEndpointRouteBuilder app) {


        app.MapPost("/receipts/new", async (ReceiptDto request, CreateReceiptHandler handler) => {
            await handler.Handle(new CreateReceiptCommand(request.number, request.date, request.items));
            return Results.Ok();
        });


        app.MapGet("/receipts", async (AppDbContext db) => {
            var repo = new ReceiptQueryRepository(db);
            var receipts = await repo.GetAllAsync();
            return Results.Ok(receipts);
        });

        return app;
    }
}





