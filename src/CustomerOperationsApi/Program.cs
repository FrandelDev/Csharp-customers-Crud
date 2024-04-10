using CustomerOperationsApi.Database.Commands.InsertCustomer;
using CustomerOperationsApi.Database.Commands.RemoveCustomer;
using CustomerOperationsApi.Database.Commands.UpdateCustomer;
using CustomerOperationsApi.Database.Queries.GetAllCustomers;
using CustomerOperationsApi.Database.Queries.GetCustomerById;
using CustomerOperationsApi.Services;
using Serilog;

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

Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File("./Logs/logs-.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

app.UseHttpLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
