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

public static class ClientEndpoints {

    public static IEndpointRouteBuilder MapClients(this IEndpointRouteBuilder app) {

        /// <summary>Запрос на создание</summary>
        app.MapPost("/clients", async (string name, string address, CreateClientHandler handler) => {
            var result = await handler.Handle(new CreateClientCommand(name, address));
            return result.Type switch {
                Result.ResultType.Success => Results.NoContent(),
                Result.ResultType.BadRequest => Results.BadRequest(result.Error),
                Result.ResultType.NotFound => Results.NotFound(result.Error),
                Result.ResultType.Conflict => Results.Conflict(result.Error),
                _ => Results.StatusCode(500)
            };
        })
        .WithName("CreateClient")
        .Produces(204)
        .Produces(400)
        .Produces(404)
        .Produces(409);

        /// <summary>Запрос на чтение всех единиц измерения</summary>
        app.MapGet("/clients", async (ReadClientsHandler handler) => {
            return Results.Ok(await handler.Handle());
        })
        .WithName("GetClients")
        .Produces<IEnumerable<ClientDto>>(200);

        /// <summary>Запрос на удаление единицы измерения</summary>
        app.MapDelete("/clients/{id:guid}", async (Guid id, DeleteClientHandler handler) => {
            await handler.Handle(new DeleteClientCommand(id));
            return Results.NoContent();
        })
        .WithName("DeleteClient");

        /// <summary>Запрос на изменение единицы измерения</summary>
        app.MapPut("/clients/{id:guid}", async (Guid id, string name, string address, UpdateClientHandler handler) => {
            var result = await handler.Handle(new UpdateClientCommand(id, name, address));
            //return Results.Created($"/resources/{result.Id}", result);
            return result.Type switch {
                Result.ResultType.Success => Results.NoContent(),
                Result.ResultType.BadRequest => Results.BadRequest(result.Error),
                Result.ResultType.NotFound => Results.NotFound(result.Error),
                Result.ResultType.Conflict => Results.Conflict(result.Error),
                _ => Results.StatusCode(500)
            };
        })
        .WithName("UpdateClient")
        .Produces(204)
        .Produces(400)
        .Produces(404)
        .Produces(409);

        return app;
    }
}