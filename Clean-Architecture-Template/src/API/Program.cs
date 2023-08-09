using API.Extensions.ServiceCollectionExt;
using Infrastructure.Repositories.UnitOfWork;
using Application.Exceptions.RuntimeExceptions;
using Infrastructure.Persistance.EFCore;
using Infrastructure.Caching.Redis;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddConnectionStrings(config: builder.Configuration);
string? mySqlConnectionString = builder.Configuration.GetConnectionString("MySql");
string? redisConnectionString = builder.Configuration.GetConnectionString("Redis");

if (mySqlConnectionString == null || redisConnectionString == null)
{
    throw new ConnectionStringException();
}

//EF Core
builder.Services.AddEFCoreMySqlDbContext(mySqlConnectionString);
//Redis
builder.Services.AddRedis(redisConnectionString);

builder.Services.AddMapperServices();
builder.Services.AddRepositoryServices();
builder.Services.AddBusinessServices();
builder.Services.AddPrimaryServices();

//UnitOfWork
builder.Services.AddEfUnitOfWork();

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
