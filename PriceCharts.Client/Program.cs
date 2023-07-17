using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PriceCharts.Client;
using PriceCharts.Client.Service;
using Syncfusion.Blazor;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });
builder.Services.AddScoped<IPriceService, PriceService>();
builder.Services.AddMudServices();
var key = builder.Configuration.GetSection("Syncfusion")["licenseKey"];
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(key);

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();