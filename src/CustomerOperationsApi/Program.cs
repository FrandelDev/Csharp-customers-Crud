using System;
using CustomerOperationsApi.Database.Commands.InsertCustomer;
using CustomerOperationsApi.Database.Commands.RemoveCustomer;
using CustomerOperationsApi.Database.Commands.UpdateCustomer;
using CustomerOperationsApi.Database.Queries.GetAllCustomers;
using CustomerOperationsApi.Database.Queries.GetCustomerById;
using CustomerOperationsApi.Services;
using Serilog;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<DatabaseService>();
        builder.Services.AddScoped<IGetAllCustomers, GetAllCustomers>();
        builder.Services.AddScoped<IGetCustomerById, GetCustomerById>();
        builder.Services.AddScoped<IAddCustomer, AddCustomer>();
        builder.Services.AddScoped<IUpdateCustomer, UpdateCustomer>();
        builder.Services.AddScoped<IRemoveCustomer, RemoveCustomer>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(option =>
        {
            option.AddPolicy("Access-Control-Allow-Origin", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });

        Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.File("./Logs/logs-.txt", rollingInterval: RollingInterval.Day)
                        .CreateLogger();

        builder.Host.UseSerilog();
        builder.Services.AddHttpLogging(o => { });

        var app = builder.Build();

        app.UseHttpLogging();

        app.UseCors("Access-Control-Allow-Origin");

        app.UseRouting();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
        }

        app.MapControllers();
        app.Run();
    }
}
