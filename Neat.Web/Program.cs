using Neat.Data;
using Neat.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// * Add services to the container.
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// * Controllers (endpoints) service
builder.Services.AddControllers();

// * Database context service
builder.Services.AddDbContext<NeatDbContext>(options =>
{
    options.EnableDetailedErrors();
    options.UseNpgsql(builder.Configuration.GetConnectionString("neat.dev"));
});

// * Endpoint functionality services
builder.Services.AddTransient<IAssetService, AssetService>();
builder.Services.AddTransient<IPropertyService, PropertyService>();

var app = builder.Build();

// * Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    // .WithOrigins("http://192.168.1.76:3000/app")
    .AllowAnyOrigin() //! TODO change this to improve security
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
