using MovieManager.Extensions;
using MovieManager.Services.Handler;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Add automapper
builder.Services.AddAutoMapper(Assembly.Load("MovieManager"));

// Add services to the container.
builder.Services.RegisterServices();
builder.Services.ConfigureCors();

builder.Services.AddDBConnection(builder.Configuration);

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

app.ConfigureException(builder.Environment);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
