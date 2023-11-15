namespace DefectReporter.Server.Data.Application
{
    #region Usings

    using DefectReporter.Shared.Models.Application;
<<<<<<< HEAD
    using DefectReporter.Shared.Models.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;

    #endregion

    /// <summary>
    /// The defect reporter db context.
    /// </summary>
=======
    using Microsoft.EntityFrameworkCore;

    #endregion

>>>>>>> 66555a5994784c2829e624147c64dc89ac1ae17d
    public class DefectReporterContext : DbContext
    {
        /// <summary>
        /// The db set of defects.
        /// </summary>
        public DbSet<Defect> Defects { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// The db set of features.
        /// </summary>
        public DbSet<Feature> Features { get; set; }

        /// <summary>
        /// The db set of releases.
        /// </summary>
        public DbSet<Release> Releases { get; set; }

        /// <summary>
=======
>>>>>>> 66555a5994784c2829e624147c64dc89ac1ae17d
        /// The db set of comments.
        /// </summary>
        public DbSet<Comment> Comments { get; set; }

        /// <summary>
<<<<<<< HEAD
        /// The db set of software builds.
        /// </summary>
        public DbSet<SoftwareBuild> SoftwareBuilds { get; set; }

        /// <summary>
=======
>>>>>>> 66555a5994784c2829e624147c64dc89ac1ae17d
        /// The defect reporter context constructor.
        /// </summary>
        /// <param name="options">
        /// The db context options.
        /// </param>
        public DefectReporterContext(DbContextOptions<DefectReporterContext> options) : base(options)
        {
        }

        /// <summary>
        /// The override of on model creating model.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Defect>();

            modelBuilder.Entity<Comment>()
                .HasOne(p => p.Defect)
                .WithMany(c => c.Comments)
<<<<<<< HEAD
                .HasForeignKey(p => p.DefectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Defect>()
                .HasOne(d => d.Owner)
                .WithMany(u => u.Defects)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Defect>()
                .HasOne(d => d.CurrentUser)
                .WithMany(u => u.CurrentUserDefects)
                .HasForeignKey(d => d.CurrentUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Defect>()
                .HasOne(d => d.Release)
                .WithOne(r => r.Defect)
                .HasForeignKey<Defect>(d => d.ReleaseId)
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Owner)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feature>()
                .HasOne(p => p.Release)
                .WithMany(c => c.Features)
                .HasForeignKey(p => p.ReleaseId)
                .IsRequired();

            modelBuilder.Entity<SoftwareBuild>()
                .HasOne(r => r.Release)
                .WithMany(f => f.SoftwareBuilds)
                .HasForeignKey(p => p.ReleaseId)
                .IsRequired();

            modelBuilder.Entity<Release>().HasData(
                new { Id = 1, Name = "Pre-Alpha" },
                new { Id = 2, Name = "Alpha" },
                new { Id = 3, Name = "Beta" }
            );
        }
=======
                .HasForeignKey(p => p.DefectId);
        }

>>>>>>> 66555a5994784c2829e624147c64dc89ac1ae17d
    }
}
