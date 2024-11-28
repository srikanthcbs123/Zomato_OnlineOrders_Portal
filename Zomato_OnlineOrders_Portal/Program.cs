using Microsoft.EntityFrameworkCore;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces;
using Zomato_OnlineOrders_Portal.DBContext;
using Zomato_OnlineOrders_Portal.RepositoryLayer;
using Zomato_OnlineOrders_Portal.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerServices>();

builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemServices, ItemServices>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderServices, OrderServices>();

builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
builder.Services.AddScoped<IOrderItemsServices, OrderItemServices>();
//create the instance for dbcontext class 
//This line indicates Entity Framework Core's dependency injection configuration
builder.Services.AddDbContext<Zomato_OnlineOrdersContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
