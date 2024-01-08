using Microsoft.EntityFrameworkCore;
using WareHousingApi.DataModel;
using WareHousingApi.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(FileNamesExtensions.AppSettingName).Build();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//DataBase
builder.Services.AddDbContextService(configuration);

//Identity
builder.Services.AddIdentityService(configuration);
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
