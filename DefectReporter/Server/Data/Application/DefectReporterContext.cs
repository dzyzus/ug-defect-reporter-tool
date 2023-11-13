﻿namespace DefectReporter.Server.Data.Application
{
    #region Usings

    using DefectReporter.Shared.Models.Application;
    using DefectReporter.Shared.Models.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;

    #endregion

    /// <summary>
    /// The defect reporter db context.
    /// </summary>
    public class DefectReporterContext : DbContext
    {
        /// <summary>
        /// The db set of defects.
        /// </summary>
        public DbSet<Defect> Defects { get; set; }

        /// <summary>
        /// The db set of features.
        /// </summary>
        public DbSet<Feature> Features { get; set; }

        /// <summary>
        /// The db set of releases.
        /// </summary>
        public DbSet<Release> Releases { get; set; }

        /// <summary>
        /// The db set of comments.
        /// </summary>
        public DbSet<Comment> Comments { get; set; }

        /// <summary>
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
                .HasForeignKey(p => p.DefectId);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(e => e.Comment)
                .WithOne(e => e.ApplicationUser)
                .HasForeignKey<Comment>(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<Feature>()
                .HasOne(p => p.Release)
                .WithMany(c => c.Features)
                .HasForeignKey(p => p.ReleaseId);

            modelBuilder.Entity<Release>().HasData(
                new { Id = 1, Name = "Pre-Alpha" },
                new { Id = 2, Name = "Alpha" },
                new { Id = 3, Name = "Beta" }
            );
        }
    }
}
