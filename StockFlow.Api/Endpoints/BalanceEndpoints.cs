using Microsoft.EntityFrameworkCore;
using StockFlow.Application;
using StockFlow.Domain;
using StockFlow.Infrastructure.Persistence;


namespace StockFlow.Api.Endpoints;


public static class BalanceEndpoints {
    public static IEndpointRouteBuilder MapIncreaseBalances(this IEndpointRouteBuilder app) {
        app.MapPost("/balances/change", async (
        ChangeBalanceRequest request,
        IncreaseBalanceService service) => {
            //var unit = new UnitOfMeasure(request.Unit, request.Ratio);


            await service.IncreaseAsync(
    request.ResourceId,
    //unit,
    request.Amount);

            return Results.Ok();
        });

        //        app.MapGet("/balances", async (AppDbContext db) => {
        //            var balances = await db.Balances
        //    .Join(
        //        db.Resources,
        //        balance => balance.ResourceId,
        //        resource => resource.Id,
        //        (balance, resource) => new BalanceDto(
        //            resource.Id,
        //            resource.Name.Value,
        //            balance.Quantity
        //        )
        //    )
        //    .ToListAsync();
        //
        //            return Results.Ok(balances);
        //        });


        app.MapGet("/balances", async (AppDbContext db) => {
            var balances = await db.Balances
                // Включаем навигационное свойство Resource (не ResourceId!)
                .Include(b => b.Resource)
                .Select(b => new BalanceDto(
                    b.Id,
                    b.Resource.Id,          // Id из Resources
                    b.Resource.Name.Value, // Name из Resources
                                           // b.Unit.Code,       // если нужно, добавьте Include для Unit
                    b.Quantity
                ))
                .ToListAsync();

            return balances;
        });


        //app.MapGet("/balances", async (AppDbContext db) => {
        //    var balances = await db.Balances
        //        .Select(b => new BalanceDto(
        //            b.ResourceId,
        //
        //            // b.Unit.Code,  // если Unit — навигация, нужно Include
        //            b.Quantity
        //        ))
        //        .ToListAsync();
        //
        //    return balances;
        //});

        return app;
    }
}