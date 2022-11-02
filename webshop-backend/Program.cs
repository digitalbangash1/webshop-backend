using webshop_backend.Auth;
using webshop_backend.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

//Services
builder.Services.AddScoped<IDbConnectionService, DbConnectionService>();
builder.Services.AddScoped<IPersonRespository, PersonRespository>();
builder.Services.AddScoped<IUserRespository, UserRepository>();
builder.Services.AddScoped<AuthI, Author>();

var app = builder.Build();

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
