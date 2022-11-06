using webshop_backend.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

//DI
builder.Services.AddScoped<IDbConnectionService, DbConnectionService>();
builder.Services.AddScoped<IPersonRespository, PersonRespository>();
builder.Services.AddScoped<IProductsRespository, ProductsRespository>();

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();
