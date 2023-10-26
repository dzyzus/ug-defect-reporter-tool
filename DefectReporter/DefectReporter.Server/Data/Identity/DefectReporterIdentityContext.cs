namespace DefectReporter.Server.Data;

#region Usings

using DefectReporter.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
#endregion

public class DefectReporterIdentityContext : IdentityDbContext<AppUser>
{
    /// <summary>
    /// The db set of defect reporter users.
    /// </summary>
    public DbSet<AppUser> Users { get; set; }

    /// <summary>
    /// The constructor of defect reporter identity.
    /// </summary>
    /// <param name="options">
    /// The db options.
    /// </param>
    public DefectReporterIdentityContext(DbContextOptions<DefectReporterIdentityContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// On model creating.
    /// </summary>
    /// <param name="modelBuilder">
    /// The model builder.
    /// </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

        modelBuilder.Entity<AppUser>();
    }
}
