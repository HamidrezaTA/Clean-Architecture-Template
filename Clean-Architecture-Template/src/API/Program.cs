using API.Extensions.ServiceCollectionExt;
using Application.Exceptions.RuntimeExceptions;
using Infrastructure.Persistance.EFCore;
using Infrastructure.Caching.Redis;
using API.Extensions.MvcOptionsExt;
using API.Extensions.WebApplicationBuilderExt;
using API.Extensions.WebApplicationExt;
using API.Extensions.ApiBehaviorOptionsExt;
using DotNetCore.CAP.Messages;
using API.Configurations;
using System.Text.RegularExpressions;
using Infrastructure.MessageBus.CAP.Extensions.ServiceCollectionExt;
using Infrastructure.MessageBus.RabbitMqClient.Extensions.ServiceCollectionExt;
using Application.MessageBus;
using Infrastructure.MessageBus;
using Infrastructure.Configurations;
using Infrastructure.MessageBus.RabbitMqClient.Consumers.Subscribers;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.Configure<ApiConfigurations>(builder.Configuration);

string? mySqlConnectionString = builder.Configuration.GetConnectionString("MySql");
string? redisConnectionString = builder.Configuration.GetConnectionString("Redis");
if (mySqlConnectionString == null || redisConnectionString == null)
    throw new ConnectionStringException();

builder.UseCustomSerilog();

//EF Core
builder.Services.AddEFCoreMySqlDbContext(connectionString: mySqlConnectionString);

//Redis
builder.Services.AddRedis(redisConnectionString: redisConnectionString);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ActionResultFilter>();
    options.Filters.Add<GlobalExceptionHandlerFilter>();
}).ConfigureApiBehaviorOptions(apiOptions =>
{
    apiOptions.AddCustomInvalidModelResponse();
});

builder.Services.AddApiVersioningService();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddMapperServices();

builder.Services.AddRepositoryServices();

builder.Services.AddBusinessServices();

builder.Services.AddValidatorServices();


var _rabbitMqConfigurations = new RabbitMqConfigurations();
builder.Configuration.GetSection("RabbitMQ").Bind(_rabbitMqConfigurations);

//Choose one of them CAP or RabbitMqClientApi

// builder.Services.AddCapExt(_rabbitMqConfigurations);

//OR
builder.Services.AddRabbitMqClient(_rabbitMqConfigurations)
                .AddConsumer<SampleConsumer>("sample-queue", false, false, false, false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
