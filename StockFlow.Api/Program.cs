using Microsoft.EntityFrameworkCore;
using StockFlow.Application.Resources;
using StockFlow.Infrastructure.Persistence;
using StockFlow.Infrastructure.Resources;

var builder = WebApplication.CreateBuilder(args);
// 1.Регистрируем API Explorer (собирает метаданные о endpoints)
builder.Services.AddEndpointsApiExplorer();
// 2.Добавляем генерацию OpenAPI/Swagger на основе метаданных из API Explorer
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<StockFlowDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
// Настраивает Entity Framework Core (EF Core) в приложении .NET, регистрируя контекст БД AppDbContext в контейнере внедрения зависимостей (DI) и указывая использовать SQLite с файлом базы данных stockflow.db.
builder.Services.AddDbContext<StockFlowDbContext>(options =>
{
    options.UseSqlite("Data Source=stockflow.db");
});

builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<CreateResourceService>();
builder.Services.AddScoped<GetResourcesService>();
builder.Services.AddScoped<DeleteResourceService>();

builder.Services.AddCors(options =>
{
options.AddDefaultPolicy(policy =>
policy.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod());
});

var app = builder.Build();

app.UseCors();

// Middleware

// Swagger включен только для разработки
// app.Environment.IsDevelopment() - встроенный чекер среды выполнения в ASP.NET Core, который возвращает true, если приложение запущено в среде Development (разработка)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// middleware в ASP.NET Core, которое автоматически перенаправляет все HTTP‑запросы на HTTPS‑версию того же ресурса.
app.UseHttpsRedirection();

app.MapPost("/resources", async (
    string name,
    CreateResourceService service,
    CancellationToken ct) =>
{
    var result = await service.CreateAsync(name, ct);
    return Results.Created($"/resources/{result.Id}", result);
});

app.MapGet("/resources", async (
    GetResourcesService service,
    CancellationToken ct) =>
{
    return Results.Ok(await service.GetAllAsync(ct));
});

app.MapDelete("/resources/{id:guid}", async (
    Guid id,
    DeleteResourceService service,
    CancellationToken ct) =>
{
    await service.DeleteAsync(id, ct);
    return Results.NoContent();
});

app.Run();