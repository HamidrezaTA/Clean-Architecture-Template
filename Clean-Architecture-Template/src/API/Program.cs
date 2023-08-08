using API.Extensions.ServiceCollectionExt;
using Infrastructure.Repositories.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConnectionStrings(config: builder.Configuration);
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
