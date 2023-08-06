using Application.Mapper;
using Infrastructure.Mapper;
using API.Extensions.MvcOptionsExt;
using API.Extensions.ServiceCollectionExt;
using Infrastructure.Caching.Redis;
using Infrastructure.Persistance.EFCore;
using Infrastructure.Repositories.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

var mySqlConnectionString = builder.Configuration.GetConnectionString("MySql");
var redisConnectionString = builder.Configuration.GetConnectionString("Redis");

//EF Core
builder.Services.AddEFCoreMySqlDbContext(mySqlConnectionString);

//Redis
builder.Services.AddRedis(redisConnectionString);

//UnitOfWork
builder.Services.AddEfUnitOfWork();

//Mapper
builder.Services.AddSingleton<IMapper, CustomMapper>();

//Action Result and Global exceptions
builder.Services.AddControllers(options =>
{
    options.AddActionResult();
    options.AddExceptionHandler();
});

// Add services to the container.
builder.Services.AddBusinessServices();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
