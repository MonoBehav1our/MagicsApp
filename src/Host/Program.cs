using DataAccess;
using DataAccess.Contracts;
using DataAccess.Repositories.Postgres;
using Host.Middleware;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<ServiceNameMiddleware>();
builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<IMagicsService, MagicsService>();
builder.Services.AddScoped<IWizardService, WizardService>();
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