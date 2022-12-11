using FashionBiz.Api;
using FashionBiz.Api.Context;
using FashionBiz.Api.Repository;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5252/");
                      });
});
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<FashionContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FashionSystemContext"));
});
builder.Services.AddScoped<ICompanyRepository, FashionBiz.Api.DAL.CompanyRepository>();
builder.Services.AddScoped<IUserRepository, FashionBiz.Api.DAL.UserRepository>();
builder.Services.AddScoped<ICustomerRepository, FashionBiz.Api.DAL.CustomerRepository>();
builder.Services.AddScoped<ICustomerMeasurementRepository, FashionBiz.Api.DAL.CustomerMeasurementRepository>();
builder.Services.AddScoped<IPaymentDetailRepository, FashionBiz.Api.DAL.PaymentDetailRepository>();
builder.Services.AddScoped<IProductCategoryRepository, FashionBiz.Api.DAL.ProductCategoryRepository>();
builder.Services.AddScoped<IProductDetailRepository, FashionBiz.Api.DAL.ProductDetailRepository>();
builder.Services.AddScoped<ISalesRepository, FashionBiz.Api.DAL.SalesRepository>();
builder.Services.AddScoped<IStockRepository, FashionBiz.Api.DAL.StockRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
