using Magics.Application.AppServices.Contracts.Magics.Handlers;
using Magics.Application.AppServices.Contracts.Magics.Repository;
using Magics.Application.AppServices.Contracts.Wizards.Handers;
using Magics.Application.AppServices.Contracts.Wizards.Repository;
using Magics.Application.AppServices.Magics.Handlers;
using Magics.Application.AppServices.Wizards.Handlers;
using Magics.Application.DataAccess.Data;
using Magics.Application.DataAccess.Magics.Repository;
using Magics.Application.DataAccess.Wizards.Repository;
using Magics.Application.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<ServiceNameMiddleware>();
builder.Services.AddScoped<MagicsDbContext>();

builder.Services.AddScoped<ISearchByFilterWizardHandler, SearchByFilterWizardHandler>();
builder.Services.AddScoped<ICreateMagicHandler, CreateMagicHandler>();
builder.Services.AddScoped<IGetStatusByIdHandler, GetStatusByIdHandler>();
builder.Services.AddScoped<IGetWizardMagics, GetWizardMagics>();

builder.Services.AddScoped<IMagicRepository, PostgresMagicRepository>();
builder.Services.AddScoped<IWizardRepository, PostgresWizardRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ServiceNameMiddleware>();

app.MapControllers();
app.UseHttpsRedirection();
app.Run();