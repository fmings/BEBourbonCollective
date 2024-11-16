using System.Text.Json.Serialization;
using BEBourbonCollective;
using BEBourbonCollective.Endpoints;
using BEBourbonCollective.Interfaces;
using BEBourbonCollective.Repositories;
using BEBourbonCollective.Services;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

// Allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Allows our API endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BourbonCollectiveDbContext>(builder.Configuration["BourbonCollectiveDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<IBourbonService, BourbonService>();
builder.Services.AddScoped<IBourbonRepository, BourbonRepository>();
builder.Services.AddScoped<IDistilleryService, DistilleryService>();
builder.Services.AddScoped<IDistilleryRepository, DistilleryRepository>();
builder.Services.AddScoped<ITradeRequestService, TradeRequestService>();
builder.Services.AddScoped<ITradeRequestRepository, TradeRequestRepository>();
builder.Services.AddScoped<IUserBourbonService, UserBourbonService>();
builder.Services.AddScoped<IUserBourbonRepository, UserBourbonRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

// Use CORS
app.UseCors();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Endpoints
BourbonEndpoints.Map(app);
DistilleryEndpoints.Map(app);
TradeRequestEndpoints.Map(app);
UserBourbonEndpoints.Map(app);
UserEndpoints.Map(app);

app.Run();
