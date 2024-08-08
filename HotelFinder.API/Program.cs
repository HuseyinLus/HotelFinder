using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAcces.Abstract;
using HotelFinder.DataAcces.Concrete;
using HotelFinder.DataAcces.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddSingleton<IHotelService, HotelsService>();
builder.Services.AddSingleton<IHotelRepository, HotelRepository>();
builder.Services.AddSingleton<ICarService, CarsService>();
builder.Services.AddSingleton<ICarRepository, CarRepository>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUsersRepository, UserRepository>();
builder.Services.AddSession();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = (doc =>
    {
        doc.Info.Title = "Hotels Api";
        doc.Info.Version = "1.0.13";
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseOpenApi();
app.UseSwaggerUi();
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
