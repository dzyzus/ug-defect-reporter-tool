namespace DefectReporter
{
    #region 

    using DefectReporter.Server.Data.Application;
    using DefectReporter.Server.Data.Identity;
    using DefectReporter.Shared.Models.Identity;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    #endregion

    /// <summary>
    /// The main program.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefectReporterUsersDb")));

            builder.Services.AddDbContext<DefectReporterContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefectReporterAppDb")));

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Local", options.ProviderOptions);
            });

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, IdentityDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();


            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Register HttpClient in DI
            builder.Services.AddHttpClient();

            builder.Services.AddControllers();

            builder.Services.AddScoped<SeedData>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseIdentityServer();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            // Create db if doesn't exist
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<DefectReporterContext>();
                var dbUserContext = services.GetRequiredService<IdentityDbContext>();

                if (!dbContext.Database.CanConnect() && !dbUserContext.Database.CanConnect())
                {
                    dbContext.Database.EnsureCreated();
                    dbUserContext.Database.EnsureCreated();

                    var seedData = services.GetRequiredService<SeedData>();
                    seedData.InitializeAsync(services);
                }
            }

            app.Run();
        }
    }
}