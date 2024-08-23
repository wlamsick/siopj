using System.Net;
using SiopjModule.Infraestructure;
using SiopjModule.WindowsService;

IHost host = Host.CreateDefaultBuilder(args)    
    .ConfigureInfraestructure()
    .ConfigureOrchestator()
    .ConfigureServices(services =>
    {
        //services.AddHostedService<Worker>();
    })
    .UseWindowsService()
    .Build();


host.Run();
