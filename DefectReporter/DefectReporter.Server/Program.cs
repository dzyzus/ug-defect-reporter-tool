using DefectReporter.Server.Data;
using DefectReporter.Server.Data.Application;
using DefectReporter.Shared.Models.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DefectReporterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefectReporterDb")));

builder.Services.AddDbContext<DefectReporterIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefectReporterUsersDb")));

builder.Services.AddDefaultIdentity<AppUser>(options =>
    options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DefectReporterIdentityContext>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Create db if doesn't exist
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<DefectReporterContext>();
    var dbUserContext = services.GetRequiredService<DefectReporterIdentityContext>();

    if (!dbContext.Database.CanConnect() && !dbUserContext.Database.CanConnect())
    {
        dbContext.Database.EnsureCreated();
        dbUserContext.Database.EnsureCreated();
    }
}

app.Run();
