/*!
 * @file ResourceEndpoints.cs
 * @brief Маршруты связанные с Балансом
 * @author -
 * @copyright -
 * @details
 *
 */
using StockFlow.Application;

namespace StockFlow.Api.Endpoints;

public static class ResourceEndpoints {

    public static IEndpointRouteBuilder MapResources(this IEndpointRouteBuilder app) {

        /// <summary></summary>
        app.MapPost("/resources", async (string name, CreateResourceService service) => {
            var result = await service.CreateAsync(name);

            //return Results.Created($"/resources/{result.Id}", result);

            return result.Type switch {
                Result.ResultType.Success => Results.NoContent(),
                Result.ResultType.BadRequest => Results.BadRequest(result.Error),
                Result.ResultType.NotFound => Results.NotFound(result.Error),
                Result.ResultType.Conflict => Results.Conflict(result.Error),
                _ => Results.StatusCode(500)
            };
        })
            .WithName("CreateResource")
            .Produces(204)
            .Produces(400)
            .Produces(404)
            .Produces(409);

        /// <summary></summary>
        app.MapGet("/resources", async (GetResourcesService service) => {
            return Results.Ok(await service.GetAllAsync());
        })
            .WithName("GetResources")
            .Produces<IEnumerable<ResourceDto>>(200);


        app.MapDelete("/resources/{id:guid}", async (
            Guid id,
            DeleteResourceService service) => {
                await service.DeleteAsync(id);
                return Results.NoContent();
            })
            .WithName("DeleteResource");

        /// <summary></summary>
        app.MapPut("/resources/{id:guid}", async (
            Guid id,
            string name,
            UpdateResourceService service) => {

                var result = await service.UpdateAsync(id, name);

                //return Results.Created($"/resources/{result.Id}", result);
                return result.Type switch {
                    Result.ResultType.Success => Results.NoContent(),
                    Result.ResultType.BadRequest => Results.BadRequest(result.Error),
                    Result.ResultType.NotFound => Results.NotFound(result.Error),
                    Result.ResultType.Conflict => Results.Conflict(result.Error),
                    _ => Results.StatusCode(500)
                };
            })
            .WithName("UpdateResource")
            .Produces(204)
            .Produces(400)
            .Produces(404)
            .Produces(409);

        return app;
    }
}