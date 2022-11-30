using webshop_backend.Auth;
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



builder.Services.AddScoped<AuthI, Author>();


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


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            // Add the following line:
            webBuilder.UseSentry(o =>
            {
                o.Dsn = "https://3c2d9f76bf0048108e065a109c10a16e@o4504162605268992.ingest.sentry.io/4504162746499072";
                // When configuring for the first time, to see what the SDK is doing:
                o.Debug = true;
                // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                o.TracesSampleRate = 1.0;
            });
        });
