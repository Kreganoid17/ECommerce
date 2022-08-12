using ECommerceApp.Client;
using ECommerceApp.Client.Repositories;
using ECommerceApp.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProvider>();
builder.Services.AddAuthenticationCore();

builder.Services.AddScoped<IUserController, UserController>();
builder.Services.AddScoped<IProductsController, ProductController>();

await builder.Build().RunAsync();
