using Microsoft.EntityFrameworkCore;
using ProductCatalog.BusinessObject;
using ProductCatalog.EFRepositories;
using ProductCatalog.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductCatalogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductCatalogContext") ?? throw new InvalidOperationException("Connection string 'ProductCatalogContext' not found.")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICatalogItemBO, CatalogItemBO>();
builder.Services.AddTransient<ICatalogItemRepository, CatalogItemRepository>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ProductCatalogContext>();
   // context.Database.Migrate();
    ProductCatalogSeed.SeedAsync(context).Wait();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
