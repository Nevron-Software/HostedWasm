using HostedWasm.Server.Services;
using Microsoft.EntityFrameworkCore;
using Nevron.Nov;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// add db context

string? connString = Environment.GetEnvironmentVariable("CONN_STR");

if (string.IsNullOrEmpty(connString))
    connString = "";

builder.Services.AddDbContext<NDbContext>(options => { options.UseSqlServer(connString); });
builder.Services.AddTransient<INOrderBlService, NOrderBl>();

// test the referenced assemblies
CultureInfo culture = NApplication.CurrentCulture;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
