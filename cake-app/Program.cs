using cake_app.Data;
using cake_app.Handlers;
using cake_app.Repositories;
using cake_app.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// register context database
string? connectionString = builder.Configuration.GetConnectionString("MySqlConnect");
builder.Services.AddDbContext<CakeContext>(x => x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), ServiceLifetime.Transient);

// register repository
builder.Services.AddScoped<CakeRepository>();

// register service
builder.Services.AddScoped<ICakeService, CakeService>();

// config graphql
builder.Services.AddGraphQLServer().AddQueryType<CakeQuery>().AddMutationType<CakeMutation>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/cake-app");

app.Run();
