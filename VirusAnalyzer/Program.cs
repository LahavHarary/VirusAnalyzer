using VirusAnalyzer.Controllers;
using VirusAnalyzer.Core;
using VirusAnalyzer.Structures.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    services.AddControllers();
    builder.Services.AddSingleton<IVirusChecker, DummyVirusChecker>();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    app.MapControllers();
    //app.UseRouting();
}

app.Run();