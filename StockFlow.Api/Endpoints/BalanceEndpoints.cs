/*!
 * @file BalanceEndpoints.cs
 * @brief Маршруты связанные с Балансом
 * @author -
 * @copyright -
 * @details
 *
 */
using Microsoft.EntityFrameworkCore;
using StockFlow.Application;
using StockFlow.Domain;
using StockFlow.Infrastructure.Persistence;

namespace StockFlow.Api.Endpoints;

public static class BalanceEndpoints {
    public static IEndpointRouteBuilder MapBalances(this IEndpointRouteBuilder app) {

        app.MapPost("/balances/change", async (ChangeBalanceRequest request, IncreaseBalanceService service) => {
            //var unit = new UnitOfMeasure(request.Unit, request.Ratio);
            await service.IncreaseAsync(request.ResourceId, /*unit,*/ request.Amount);
            return Results.Ok();
        });

        app.MapGet("/balances", async (AppDbContext db) => {
            var balances = await db.Balances
                // Включаем навигационное свойство Resource (не ResourceId!)
                .Include(b => b.Resource)
                .Select(b => new BalanceDto(
                    b.Id,
                    b.Resource.Id,          // Id из Resources
                    b.Resource.Name.Value, // Name из Resources
                    /*b.Unit.Code,*/       // если нужно, добавьте Include для Unit
                    b.Quantity
                )).ToListAsync();
            return balances;
        });

        return app;
    }
}