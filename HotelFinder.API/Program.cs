using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAcces.Abstract;
using HotelFinder.DataAcces.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();
builder.Services.AddSingleton<IHotelService, HotelManeger>();
builder.Services.AddSingleton<IHotelRepository1, HotelRepository>();
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = (doc =>
    {
        doc.Info.Title = "Hotels Api";
        doc.Info.Version = "1.0.13";
    });
}); ;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseOpenApi();
app.UseSwaggerUi();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
