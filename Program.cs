using APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.DapperDbConnection;
using APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.DatabaseContext;
using APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.Repository;
using APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.ServiceContracts;
using APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Access configuration from the builder
var configuration = builder.Configuration;

// Add services to the container.
// Add Dapper connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Add repositories and services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDapperDbConnection, DapperDbConnection>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Devlopment Using Dapper and Stored Procedure with AspNET Core Web API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Devlopment Using Dapper and Stored Procedure with AspNET Core Web API");
        // Configure additional settings for SwaggerUI if needed
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
