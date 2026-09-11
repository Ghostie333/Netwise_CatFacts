using NetwiseApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Dodanie serwisu od zapytania api oraz od obsługi pliku do zapisu faktów
builder.Services.AddHttpClient<ICatFactService, CatFactService>(c =>
    c.BaseAddress = new Uri("https://catfact.ninja/"));
builder.Services.AddScoped<IFileService, FileService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Do wwwroot
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();

app.Run();
