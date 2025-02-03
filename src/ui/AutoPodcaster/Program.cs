using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Blazored.LocalStorage;
using AutoPodcaster;
using AutoPodcaster.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Input Service
builder.Services.AddScoped<IInputService, InputService>();
builder.Services.AddKeyedScoped("InputBackend", (sp, key) => new HttpClient { BaseAddress = new Uri(builder.Configuration["InputBackendUrl"] ?? "http://localhost:8081") });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();
