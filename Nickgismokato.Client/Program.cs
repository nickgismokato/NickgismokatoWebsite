using NLog;
using NLog.Extensions.Logging;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault( args );



AddBlazorise( builder.Services );

LogManager.Setup().LoadConfigurationFromFile("nlog.config");

string pathLog = "/var/log/website";
if(Directory.Exists(pathLog)){
    foreach(var file in Directory.GetFiles(pathLog)){
        File.Delete(file);
    }
}

// Correctly register Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage(config =>{
    config.JsonSerializerOptions.WriteIndented = true;
});


await builder.Build().RunAsync();
//private static Logger logger = LogManager.GetCurrentClassLogger();

void AddBlazorise( IServiceCollection services ){
    services
        //.AddBlazorise(options => options.Immediate = true)
        .AddBlazorise()
        .AddBootstrap5Providers()
        .AddFontAwesomeIcons();
}