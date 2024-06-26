using Blazored.LocalStorage;
using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.Providers;
using HrLeaveManagement.Server.Client.Services;
using HrLeaveManagement.Server.Client.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//builder.Services.AddScoped(Sp=>new HttpClient { BaseAddress=new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IClient, Client>
    (client => client.BaseAddress = new Uri("https://localhost:7249"));

builder.Services.AddScoped<ILeaveTypeService,LeaveTypeService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IAuthenticationService,AuthenticationService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider,ApiAuthenticationStateProvider>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
await builder.Build().RunAsync();
