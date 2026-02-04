using Microsoft.EntityFrameworkCore;
using StockFlow.Application;
using StockFlow.Infrastructure.Persistence;
using StockFlow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// 1.Регистрируем API Explorer (собирает метаданные о endpoints)
builder.Services.AddEndpointsApiExplorer();
// 2.Добавляем генерацию OpenAPI/Swagger на основе метаданных из API Explorer
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<StockFlowDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
// Настраивает Entity Framework Core (EF Core) в приложении .NET, регистрируя контекст БД AppDbContext в контейнере внедрения зависимостей (DI) и указывая использовать SQLite с файлом базы данных stockflow.db.
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlite("Data Source=stockflow.db");
});

builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<CreateResourceService>();
builder.Services.AddScoped<GetResourcesService>();
builder.Services.AddScoped<DeleteResourceService>();
builder.Services.AddScoped<UpdateResourceService>();

// Cors
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

var app = builder.Build();

// Cors
app.UseCors();

// Middleware
// Swagger включен только для разработки
// app.Environment.IsDevelopment() - встроенный чекер среды выполнения в ASP.NET Core, который возвращает true, если приложение запущено в среде Development (разработка)
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
// middleware в ASP.NET Core, которое автоматически перенаправляет все HTTP‑запросы на HTTPS‑версию того же ресурса.
app.UseHttpsRedirection();

app.MapPost("/resources", async (
    string name,
    CreateResourceService service) => {
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

app.MapGet("/resources", async (
    GetResourcesService service) => {
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

app.Run();