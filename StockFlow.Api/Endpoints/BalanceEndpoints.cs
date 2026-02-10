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
            Console.WriteLine("Ошшшибка: ResourceId = {0} Amount = {1}", request.ResourceId, request.Amount);

            //var unit = new UnitOfMeasure(request.Unit, request.Ratio);
            await service.IncreaseAsync(request.ResourceId, /*unit,*/ request.Amount);
            return Results.Ok();
        });


        app.MapPost("/balances/changes", async (ChangeBalanceRequest[] requests, IncreaseBalanceHandler service) => {
            //Console.WriteLine("Ошшшибка: ResourceId = {0} Amount = {1}", request.ResourceId, request.Amount);


            var commands = requests.Select(r => new IncreaseBalanceCommand(r.ResourceId, (int)r.Amount)).ToArray();
            //var unit = new UnitOfMeasure(request.Unit, request.Ratio);
            await service.IncreaseAsync(commands);
            return Results.Ok();



            // Десериализуем JSON из тела запроса в массив ProductDto
            //using var reader = new StreamReader(context.Request.Body);
            //var json = await reader.ReadToEndAsync();
            //var requests = System.Text.Json.JsonSerializer.Deserialize<ChangeBalanceRequest[]>(json);
            //
            //
            ////if (requests == null || requests.Length == 0) {
            ////    context.Response.StatusCode = 400;
            ////    await context.Response.WriteAsJsonAsync(new { error = "Массив пуст или невалиден" });
            ////    return;
            ////}
            //
            //var commands = requests.Select(r => new IncreaseBalanceCommand(r.ResourceId, (int)r.Amount)).ToArray();
            ////var unit = new UnitOfMeasure(request.Unit, request.Ratio);
            //await service.IncreaseAsync(commands);
            //return Results.Ok();
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





