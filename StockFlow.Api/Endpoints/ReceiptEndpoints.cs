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
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Api.Endpoints;

public static class ReceiptEndpoints {
    public static IEndpointRouteBuilder MapReceipts(this IEndpointRouteBuilder app) {


        app.MapPost("/receipts/new", async (ReceiptDto request, CreateReceiptHandler handler) => {
            await handler.Handle(new CreateReceiptCommand(request.number, request.date, request.items));
            return Results.Ok();
        });
        //
        //app.MapGet("/balances", async (AppDbContext db) => {
        //    var balances = await db.Balances
        //        // Включаем навигационное свойство Resource (не ResourceId!)
        //        .Include(b => b.Resource)
        //        .Select(b => new BalanceDto(
        //            b.Id,
        //            b.Resource.Id,          // Id из Resources
        //            b.Resource.Name.Value, // Name из Resources
        //            /*b.Unit.Code,*/       // если нужно, добавьте Include для Unit
        //            b.Quantity
        //        )).ToListAsync();
        //    return balances;
        //});

        return app;
    }
}





