using Microsoft.EntityFrameworkCore;
using StockFlow.Application.UseCases;
using StockFlow.Application.Repositories;
using StockFlow.Infrastructure.Persistence;
using StockFlow.Infrastructure;
using StockFlow.Api.Endpoints;

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
// Resource
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<CreateResourceService>();
builder.Services.AddScoped<GetResourcesService>();
builder.Services.AddScoped<DeleteResourceService>();
builder.Services.AddScoped<UpdateResourceService>();
// Unit
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<CreateUnitHandler>();
builder.Services.AddScoped<ReadUnitsHandler>();
builder.Services.AddScoped<UpdateUnitHandler>();
builder.Services.AddScoped<DeleteUnitHandler>();
// Client
builder.Services.AddScoped<CreateClientHandler>();
builder.Services.AddScoped<ReadClientsHandler>();
builder.Services.AddScoped<UpdateClientHandler>();
builder.Services.AddScoped<DeleteClientHandler>();
//Balance
builder.Services.AddScoped<IncreaseBalanceService>();
builder.Services.AddScoped<IncreaseBalanceHandler>();

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

app.MapResources();
app.MapUnits();
app.MapClients();
app.MapBalances();

app.Run();