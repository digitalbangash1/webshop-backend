using webshop_backend.Repositories;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://samat.admin.samat.diplomportal.dk/",
                                              "https://samat.admin.samat.diplomportal.dk/",
                                              "https://localhost:3000/",
                                              "https://user-images.githubusercontent.com");
                      });
});

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
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IShoppingcartRespository, ShoppingCartRespository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);


app.Run();
