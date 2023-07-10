using ApplicationLayer.Abstract;
using ApplicationLayer.Concrete;
using InfrastructureLayer.Abstract;
using InfrastructureLayer.Concrete;
using InfrastructureLayer.SqlContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//// ---------------Service-------------------- /

builder.Services.AddScoped(typeof(IEmployeeService), typeof(EmployeeManager));
builder.Services.AddScoped(typeof(IOrderService), typeof(OrderManager));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductManager));



//// ----------------DAL------------------ /
builder.Services.AddScoped(typeof(IEmployeeDal), typeof(EmployeeRepository));
builder.Services.AddScoped(typeof(IOrderDal), typeof(OrdersRepository));
builder.Services.AddScoped(typeof(IProductDal), typeof(ProductRepository));



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
