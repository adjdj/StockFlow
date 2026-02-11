/*!
 * @file UnitEndpoints.cs
 * @brief Маршруты связанные с Балансом
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Application;
using StockFlow.Application.Contracts;
using StockFlow.Application.UseCases;

namespace StockFlow.Api.Endpoints;

public static class UnitEndpoints {

    public static IEndpointRouteBuilder MapUnits(this IEndpointRouteBuilder app) {

        /// <summary>Запрос на создание новой единицы измерения</summary>
        app.MapPost("/units", async (string name, CreateUnitHandler handler) => {
            var result = await handler.Handle(new CreateUnitCommand(name));
            return result.Type switch {
                Result.ResultType.Success => Results.NoContent(),
                Result.ResultType.BadRequest => Results.BadRequest(result.Error),
                Result.ResultType.NotFound => Results.NotFound(result.Error),
                Result.ResultType.Conflict => Results.Conflict(result.Error),
                _ => Results.StatusCode(500)
            };
        })
        .WithName("CreateUnit")
        .Produces(204)
        .Produces(400)
        .Produces(404)
        .Produces(409);

        /// <summary>Запрос на чтение всех единиц измерения</summary>
        app.MapGet("/units", async (ReadUnitsHandler handler) => {
            return Results.Ok(await handler.Handle());
        })
        .WithName("GetUnits")
        .Produces<IEnumerable<UnitDto>>(200);

        /// <summary>Запрос на удаление единицы измерения</summary>
        app.MapDelete("/units/{id:guid}", async (Guid id, DeleteUnitHandler handler) => {
            await handler.Handle(new DeleteUnitCommand(id));
            return Results.NoContent();
        })
        .WithName("DeleteUnit");

        /// <summary>Запрос на изменение единицы измерения</summary>
        app.MapPut("/units/{id:guid}", async (Guid id, string name, UpdateUnitHandler handler) => {
            var result = await handler.Handle(new UpdateUnitCommand(id, name));
            //return Results.Created($"/resources/{result.Id}", result);
            return result.Type switch {
                Result.ResultType.Success => Results.NoContent(),
                Result.ResultType.BadRequest => Results.BadRequest(result.Error),
                Result.ResultType.NotFound => Results.NotFound(result.Error),
                Result.ResultType.Conflict => Results.Conflict(result.Error),
                _ => Results.StatusCode(500)
            };
        })
        .WithName("UpdateUnit")
        .Produces(204)
        .Produces(400)
        .Produces(404)
        .Produces(409);

        return app;
    }
}