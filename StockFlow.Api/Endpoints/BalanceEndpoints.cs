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

public static class BalanceEndpoints {
    public static IEndpointRouteBuilder MapBalances(this IEndpointRouteBuilder app) {


        app.MapPost("/balances/change", async (ChangeBalanceRequest request, IncreaseBalanceService service) => {
            await service.IncreaseAsync(request.ResourceId, request.UnitId, request.Amount);
            return Results.Ok();
        });

        app.MapPost("/balances/changes", async (ChangeBalanceRequest[] requests, IncreaseBalanceHandler service) => {
            var commands = requests.Select(r => new IncreaseBalanceCommand(r.ResourceId, r.UnitId, (int)r.Amount)).ToArray();
            await service.IncreaseAsync(commands);
            return Results.Ok();
        });

        app.MapGet("/balances", async (AppDbContext db) => {
            var balances = await db.Balances
                // Включаем навигационное свойство Resource (не ResourceId!)
                .Include(b => b.Resource)
                //.Where(b => b.Resource != null)
                .Select(b => new BalanceDto(
                    b.Id,
                    //b.Resource.Id,          // Id из Resources
                    b.Resource != null ? b.Resource.Name.Value : "N/A",// Name из Resources
                    b.Unit != null ? b.Unit.Name.Value : "N/A", // Name из Unit
                    b.Quantity
                )).ToListAsync();
            return balances;
        });

        return app;
    }
}





