namespace DefectReporter.Server.Data.Application
{
    using AutoMapper.Features;
    using DefectReporter.Shared.Enums;
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
        /// The db set of software builds.
        /// </summary>
        public DbSet<SoftwareBuild> SoftwareBuilds { get; set; }

        /// <summary>
        /// The db set of tests.
        /// </summary>
        public DbSet<Test> Tests { get; set; }

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
                .HasForeignKey(p => p.DefectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Defect>()
                .HasOne(d => d.Release)
                .WithMany(r => r.Defects)
                .HasForeignKey(d => d.ReleaseId)
                .IsRequired();

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

            modelBuilder.Entity<Test>()
                .HasOne(t => t.Feature)
                .WithMany(f => f.Tests)
                .HasForeignKey(t => t.FeatureId)
                .IsRequired();

            modelBuilder.Entity<Release>().HasData(
                new { Id = 1, Name = "Pre-Alpha" },
                new { Id = 2, Name = "Alpha" },
                new { Id = 3, Name = "Beta" }
                );

            modelBuilder.Entity<SoftwareBuild>().HasData(
                new { Id = 1, SoftwareVersion = "SW_1.0.0.1", ReleaseId = 1 },
                new { Id = 2, SoftwareVersion = "SW_1.0.0.2", ReleaseId = 1 },
                new { Id = 3, SoftwareVersion = "SW_1.0.0.3", ReleaseId = 1 },
                new { Id = 4, SoftwareVersion = "SW_1.0.0.4", ReleaseId = 1 },
                new { Id = 5, SoftwareVersion = "SW_1.0.0.5", ReleaseId = 1 },
                new { Id = 6, SoftwareVersion = "SW_1.0.0.6", ReleaseId = 1 },
                new { Id = 7, SoftwareVersion = "SW_1.0.0.7", ReleaseId = 1 },
                new { Id = 8, SoftwareVersion = "SW_1.0.0.8", ReleaseId = 1 },
                new { Id = 9, SoftwareVersion = "SW_1.0.0.9", ReleaseId = 1 },
                new { Id = 10, SoftwareVersion = "SW_1.0.1.1", ReleaseId = 2 },
                new { Id = 11, SoftwareVersion = "SW_1.0.1.2", ReleaseId = 2 },
                new { Id = 12, SoftwareVersion = "SW_1.0.1.3", ReleaseId = 2 },
                new { Id = 13, SoftwareVersion = "SW_1.0.1.4", ReleaseId = 2 },
                new { Id = 14, SoftwareVersion = "SW_1.0.1.5", ReleaseId = 2 },
                new { Id = 15, SoftwareVersion = "SW_1.0.1.6", ReleaseId = 2 },
                new { Id = 16, SoftwareVersion = "SW_1.0.1.7", ReleaseId = 2 },
                new { Id = 17, SoftwareVersion = "SW_1.0.1.8", ReleaseId = 2 },
                new { Id = 18, SoftwareVersion = "SW_1.0.1.9", ReleaseId = 2 },
                new { Id = 19, SoftwareVersion = "SW_1.0.2.1", ReleaseId = 3 },
                new { Id = 20, SoftwareVersion = "SW_1.0.2.2", ReleaseId = 3 },
                new { Id = 21, SoftwareVersion = "SW_1.0.2.3", ReleaseId = 3 },
                new { Id = 22, SoftwareVersion = "SW_1.0.2.4", ReleaseId = 3 },
                new { Id = 23, SoftwareVersion = "SW_1.0.2.5", ReleaseId = 3 },
                new { Id = 24, SoftwareVersion = "SW_1.0.2.6", ReleaseId = 3 },
                new { Id = 25, SoftwareVersion = "SW_1.0.2.7", ReleaseId = 3 },
                new { Id = 26, SoftwareVersion = "SW_1.0.2.8", ReleaseId = 3 },
                new { Id = 27, SoftwareVersion = "SW_1.0.2.9", ReleaseId = 3 }
                );

            modelBuilder.Entity<Feature>().HasData(
                new { Id = 1, Title = "Login into account", Description = "The possibility to login to user account", Component = ComponentEnum.Authentication, ReleaseId = 1 },
                new { Id = 2, Title = "Register account", Description = "Register new users", Component = ComponentEnum.Authentication, ReleaseId = 1 },
                new { Id = 3, Title = "Logout", Description = "The possibility to logout", Component = ComponentEnum.Authentication, ReleaseId = 1 },
                new { Id = 4, Title = "Defect model", Description = "Entity of defect in database", Component = ComponentEnum.Data, ReleaseId = 1 },
                new { Id = 5, Title = "Feature model", Description = "Entity of feature in database", Component = ComponentEnum.Data, ReleaseId = 1 },
                new { Id = 6, Title = "Defect creator", Description = "CRUD of defect model", Component = ComponentEnum.Feature, ReleaseId = 2 },
                new { Id = 7, Title = "Feature creator", Description = "CRUD of feature model", Component = ComponentEnum.Feature, ReleaseId = 2 },
                new { Id = 8, Title = "Defect statistic", Description = "Statistics of defects in database", Component = ComponentEnum.Feature, ReleaseId = 2 }
                );

            modelBuilder.Entity<Test>().HasData(
                new
                {
                    Id = 1,
                    TestName = "Check correctness of data while registration",
                    TestCase = "1. Open the registration form\n2. Provide correct data\n3. Check the registration with correct data will be completed",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Functional,
                    FeatureId = 2,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                    Id = 2,
                    TestName = "Check registration proccess with incorrect data",
                    TestCase = "1. Open the registration form\n2. Provide incorrect data\n3. Check the registration with incorrect data will be interrupted",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Security,
                    FeatureId = 2,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                    Id = 3,
                    TestName = "Check login process with correct data",
                    TestCase = "1. Open the login form\n2. Provide correct data\n3. Check the login proccess will be completed",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Functional,
                    FeatureId = 1,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                    Id = 4,
                    TestName = "Check login process with incorrect data",
                    TestCase = "1. Open the login form\n2. Provide incorrect data\n3. Check the login proccess will be interrupted",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Security,
                    FeatureId = 1,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                Id = 5,
                    TestName = "Check the url will be opened properly",
                    TestCase = "1. Provide url\n2. Check the provided url will be opened properly",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Smoke,
                    FeatureId = 1,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                Id = 6,
                    TestName = "Check the url will be opened properly",
                    TestCase = "1. Provide url\n2. Check the provided url will be opened properly",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Smoke,
                    FeatureId = 2,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                Id = 7,
                    TestName = "Check the url will be opened properly",
                    TestCase = "1. Provide url\n2. Check the provided url will be opened properly",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Smoke,
                    FeatureId = 3,
                    Component = ComponentEnum.Feature
                }
                );

            modelBuilder.Entity<Feature>().HasMany(f => f.Tests).WithOne(t => t.Feature).HasForeignKey(t => t.FeatureId);
        }
    }
}
