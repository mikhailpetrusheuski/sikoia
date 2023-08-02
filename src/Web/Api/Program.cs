using Api.Extensions;
using Company.Integration.CompanyA.Services;
using Company.Integration.CompanyB.Services;
using Company.Integration.Factories;
using Company.Integration.Infrastructure.Factories;
using Company.Integration.Infrastructure.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddHttpClient<ICompanyService, CompanyServiceA>(c => c.BaseAddress = new Uri("https://interview-df854r23.sikoia.com"))
    .AddRetryPolicy();

builder.Services
    .AddHttpClient<ICompanyService, CompanyServiceB>(c => c.BaseAddress = new Uri("https://interview-df854r23.sikoia.com"))
    .AddRetryPolicy();

// Add Mapster
builder.Services.RegisterMappings();

builder.Services.AddTransient<ICompanyServiceFactory, CompanyServiceFactory>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

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