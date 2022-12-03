using GestaoDeVendas.Web;
using GestaoDeVendas.Web.Services.Layout;
using GestaoDeVendas.Web.Services.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;


Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzcxNDQ3QDMyMzAyZTMzMmUzME9rQnZqeVJrOEdJQzRkTmhycnZ4dDBRejZhMGpoa2ovUmUyR1RqTW40bEk9");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddCors();

builder.Services.AddOptions();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddAuthorizationCore();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var baseUrl = "https://localhost:7142";
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(baseUrl)
});

//serviços
builder.Services.AddScoped<IProdutoService, ProdutoServices>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();




await builder.Build().RunAsync();
