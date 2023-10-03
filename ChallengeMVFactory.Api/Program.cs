
using ChallengeMVFactory.Api.Middleware;
using ChallengeMVFactory.Application;
using ChallengeMVFactory.Application.Models;
using ChallengeMVFactory.Infrastructure;
using ChallengeMVFactory.Infrastructure.Persistence;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
;
builder.Services.Configure<AppSetting>(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
    

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "cors", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddAplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");
app.UseMiddleware<ExcepctionMiddlare>();
app.UseAuthorization();

app.MapControllers();

await SeedData(app);

 
app.Run();


async Task  SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        await service.Seed();
    }
}

