using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAcces.Abstract;
using HotelFinder.DataAcces.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using System.Reflection.Metadata.Ecma335;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Register services
builder.Services.AddControllers();
builder.Services.AddSingleton<IHotelService, HotelsService>();
builder.Services.AddSingleton<IHotelRepository, HotelRepository>();
builder.Services.AddSingleton<ICarService, CarsService>();
builder.Services.AddSingleton<ICarRepository, CarRepository>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUsersRepository, UserRepository>();
builder.Services.AddSingleton<ILoginService, LoginServicecs>();
builder.Services.AddSingleton<ILoginRepository, LoginRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = (doc =>
    {
        doc.Info.Title = "Hotels Api";
        doc.Info.Version = "1.0.13";
    });
    config.AddSecurity("Bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
    {
        Type = OpenApiSecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = NSwag.OpenApiSecurityApiKeyLocation.Header,
        Name = "Authorization",
        Description = "Input your JWT token like this: Bearer {your JWT token here}"
    });

    config.OperationProcessors.Add(new NSwag.Generation.Processors.Security.OperationSecurityScopeProcessor("Bearer"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseOpenApi();
app.UseSwaggerUi();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
