using HomeAssignmentCountriesApi.ApiLogic;
using Refit;

var builder = WebApplication.CreateBuilder(args);


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddRefitClient<IRestCountriesApi>().ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(configuration["IRestCountriesApi:BaseAddress"]);
    }
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();