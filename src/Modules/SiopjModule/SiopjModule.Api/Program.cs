using SiopjModule.Infraestructure;
using SiopjModule.Application;
using SiopjModule.Presentation;
using SiopjModule.Presentation.Modules;

var builder = WebApplication.CreateBuilder(args);

// Configure Infraestucture
builder.ConfigureInfraestructure();
//builder.ConfigureOrchestator();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationServices();
builder.Services.AddLogging();

builder.ConfigureEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpointModule<SiopjEndpointModule>();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.Run();
