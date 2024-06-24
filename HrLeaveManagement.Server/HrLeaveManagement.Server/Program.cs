
using Blazored.LocalStorage;
using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.Services;
using HrLeaveManagement.Server.Client.Services.Base;
using HrLeaveManagement.Server.Components;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


builder.Services.AddHttpClient<IClient, Client>
    (client => client.BaseAddress = new Uri("https://localhost:7249"));

builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(HrLeaveManagement.Server.Client._Imports).Assembly);

app.Run();
