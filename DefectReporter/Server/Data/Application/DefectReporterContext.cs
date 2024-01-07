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

            modelBuilder.Entity<Defect>()
                .HasOne(d => d.SoftwareBuild)
                .WithMany(r => r.Defects)
                .HasForeignKey(d => d.SoftwareId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Defect>()
                .HasOne(d => d.Test)
                .WithMany(r => r.Defects)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.NoAction);

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
                },
                new
                {
                    Id = 8,
                    TestName = "Check the correctness of data during account registration",
                    TestCase = "1. Open the account registration form\n2. Provide correct data\n3. Check if the account registration with correct data will be completed",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Functional,
                    FeatureId = 2,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                    Id = 9,
                    TestName = "Check the account registration process with incorrect data",
                    TestCase = "1. Open the account registration form\n2. Provide incorrect data\n3. Check if the account registration with incorrect data will be interrupted",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Security,
                    FeatureId = 2,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                    Id = 10,
                    TestName = "Check the login process with correct data",
                    TestCase = "1. Open the login form\n2. Provide correct data\n3. Check if the login process will be completed",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Functional,
                    FeatureId = 1,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                    Id = 11,
                    TestName = "Check the login process with incorrect data",
                    TestCase = "1. Open the login form\n2. Provide incorrect data\n3. Check if the login process will be interrupted",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Security,
                    FeatureId = 1,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                    Id = 12,
                    TestName = "Check if the URL will be opened properly",
                    TestCase = "1. Provide URL\n2. Check if the provided URL will be opened properly",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Smoke,
                    FeatureId = 1,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                    Id = 13,
                    TestName = "Check if the URL will be opened properly",
                    TestCase = "1. Provide URL\n2. Check if the provided URL will be opened properly",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Smoke,
                    FeatureId = 2,
                    Component = ComponentEnum.Authentication
                },
                new
                {
                    Id = 14,
                    TestName = "Check if the URL will be opened properly",
                    TestCase = "1. Provide URL\n2. Check if the provided URL will be opened properly",
                    IsAutomated = true,
                    TypeOfTest = TypeOfTest.Smoke,
                    FeatureId = 3,
                    Component = ComponentEnum.Feature
                }
                );

            modelBuilder.Entity<Defect>().HasData(
                new
                {
                    Id = 1,
                    Title = "[AUTH] Can't confirm my email",
                    Description = "1. Register new account\n2. Notice that the email can not be confirmed",
                    ReleaseId = 1,
                    IsRegression = false,
                    IsFixed = false,
                    Created = DateTime.Now.AddDays(-10),
                    CompletedReason = DefectCompletedReasonEnum.InProgress,
                    Status = DefectStatusEnum.Open,
                    Component = ComponentEnum.Authentication,
                    SoftwareId = 1,
                    TestId = 1,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                },
                new
                {
                    Id = 2,
                    Title = "[AUTH] The registration button from login view is not working",
                    Description = "1. Go to login view\n2. Try go to register view from login view",
                    ReleaseId = 1,
                    IsRegression = true,
                    Created = DateTime.Now.AddDays(-9),
                    IsFixed = false,
                    Status = DefectStatusEnum.Open,
                    CompletedReason = DefectCompletedReasonEnum.InProgress,
                    Component = ComponentEnum.Authentication,
                    SoftwareId = 2,
                    TestId = 1,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                },
                new
                {
                    Id = 3,
                    Title = "[AUTH] The registration button from login view is not working",
                    Description = "1. Go to login view\n2. Try go to register view from login view",
                    ReleaseId = 1,
                    IsRegression = true,
                    Created = DateTime.Now.AddDays(-9),
                    CompletedReason = DefectCompletedReasonEnum.NotADefect,
                    IsFixed = true,
                    Status = DefectStatusEnum.Rejected,
                    Component = ComponentEnum.Authentication,
                    SoftwareId = 2,
                    TestId = 1,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                },
                new
                {
                    Id = 4,
                    Title = "[AUTH] Password reset not working",
                    Description = "1. Click on 'Forgot Password'\n2. Provide the email\n3. Check if the password reset link is sent",
                    ReleaseId = 1,
                    IsRegression = false,
                    IsFixed = false,
                    CompletedReason = DefectCompletedReasonEnum.InProgress,
                    Created = DateTime.Now.AddDays(-8),
                    Status = DefectStatusEnum.Open,
                    Component = ComponentEnum.Authentication,
                    SoftwareId = 3,
                    TestId = 2,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                },
                new
                {
                    Id = 5,
                    Title = "[DATA] Unable to save data changes",
                    Description = "1. Make changes to data\n2. Save the changes\n3. Check if the changes are saved properly",
                    ReleaseId = 1,
                    IsRegression = false,
                    IsFixed = false,
                    Created = DateTime.Now.AddDays(-7),
                    Status = DefectStatusEnum.Open,
                    CompletedReason = DefectCompletedReasonEnum.InProgress,
                    Component = ComponentEnum.Data,
                    SoftwareId = 4,
                    TestId = 3,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                },
                new
                {
                    Id = 6,
                    Title = "[FEATURE] Missing button for new feature",
                    Description = "1. Open the feature creation screen\n2. Check if there is a button to create a new feature",
                    ReleaseId = 2,
                    IsRegression = false,
                    IsFixed = false,
                    Created = DateTime.Now.AddDays(-6),
                    CompletedReason = DefectCompletedReasonEnum.InProgress,
                    Status = DefectStatusEnum.Open,
                    Component = ComponentEnum.Feature,
                    SoftwareId = 5,
                    TestId = 4,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                },
                new
                {
                    Id = 7,
                    Title = "[DATA] Unable to delete records",
                    Description = "1. Attempt to delete a record\n2. Check if the record is successfully deleted",
                    ReleaseId = 2,
                    IsRegression = false,
                    IsFixed = false,
                    Created = DateTime.Now.AddDays(-5),
                    CompletedReason = DefectCompletedReasonEnum.InProgress,
                    Status = DefectStatusEnum.Open,
                    Component = ComponentEnum.Data,
                    SoftwareId = 6,
                    TestId = 5,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                },
                new
                {
                    Id = 8,
                    Title = "[FEATURE] Incorrect sorting in feature list",
                    Description = "1. Open the feature list\n2. Check if the features are sorted correctly",
                    ReleaseId = 2,
                    IsRegression = false,
                    IsFixed = false,
                    Created = DateTime.Now.AddDays(-4),
                    CompletedReason = DefectCompletedReasonEnum.InProgress,
                    Status = DefectStatusEnum.Open,
                    Component = ComponentEnum.Feature,
                    SoftwareId = 7,
                    TestId = 6,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                },
                new
                {
                    Id = 9,
                    Title = "[DATA] Data integrity issue",
                    Description = "1. Perform multiple data operations\n2. Check if the data integrity is maintained",
                    ReleaseId = 2,
                    IsRegression = false,
                    IsFixed = false,
                    Created = DateTime.Now.AddDays(-3),
                    CompletedReason = DefectCompletedReasonEnum.InProgress,
                    Status = DefectStatusEnum.Open,
                    Component = ComponentEnum.Data,
                    SoftwareId = 8,
                    TestId = 7,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                },
                new
                {
                    Id = 10,
                    Title = "[FEATURE] Missing feature details",
                    Description = "1. Open the details of a feature\n2. Check if all details are displayed",
                    ReleaseId = 2,
                    IsRegression = false,
                    IsFixed = false,
                    Created = DateTime.Now.AddDays(-2),
                    CompletedReason = DefectCompletedReasonEnum.InProgress,
                    Status = DefectStatusEnum.Open,
                    Component = ComponentEnum.Feature,
                    SoftwareId = 9,
                    TestId = 8,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                },
                new
                {
                    Id = 11,
                    Title = "[FEATURE] Incorrect display of feature status",
                    Description = "1. Open the feature details\n2. Check if the status of the feature is displayed correctly",
                    ReleaseId = 3,
                    IsRegression = false,
                    IsFixed = true,
                    CompletedReason = DefectCompletedReasonEnum.Fixed,
                    FixedOnVersion = "SW_1.0.2.2",
                    Created = DateTime.Now.AddDays(-10),
                    Status = DefectStatusEnum.Resolved,
                    Component = ComponentEnum.Feature,
                    SoftwareId = 10,
                    TestId = 9,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                    End = DateTime.Now.AddDays(-9)
                },
                new
                {
                    Id = 12,
                    Title = "[AUTH] Password reset link not expiring",
                    Description = "1. Click on 'Forgot Password'\n2. Provide the email\n3. Check if the password reset link is expiring properly",
                    ReleaseId = 3,
                    IsRegression = false,
                    IsFixed = true,
                    CompletedReason = DefectCompletedReasonEnum.Fixed,
                    FixedOnVersion = "SW_1.0.2.3",
                    Created = DateTime.Now.AddDays(-9),
                    Status = DefectStatusEnum.Resolved,
                    Component = ComponentEnum.Authentication,
                    SoftwareId = 11,
                    TestId = 10,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                    End = DateTime.Now.AddDays(-8)
                },
                new
                {
                    Id = 13,
                    Title = "[DATA] Unable to update records",
                    Description = "1. Attempt to update a record\n2. Check if the record is successfully updated",
                    ReleaseId = 3,
                    IsRegression = false,
                    IsFixed = true,
                    CompletedReason = DefectCompletedReasonEnum.Fixed,
                    FixedOnVersion = "SW_1.0.2.4",
                    Created = DateTime.Now.AddDays(-8),
                    Status = DefectStatusEnum.Resolved,
                    Component = ComponentEnum.Data,
                    SoftwareId = 12,
                    TestId = 11,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                    End = DateTime.Now.AddDays(-7)
                },
                new
                {
                    Id = 14,
                    Title = "[FEATURE] Missing feature images",
                    Description = "1. Open the feature details\n2. Check if the images associated with the feature are displayed",
                    ReleaseId = 3,
                    IsRegression = false,
                    IsFixed = true,
                    CompletedReason = DefectCompletedReasonEnum.Fixed,
                    FixedOnVersion = "SW_1.0.2.5",
                    Created = DateTime.Now.AddDays(-7),
                    Status = DefectStatusEnum.Resolved,
                    Component = ComponentEnum.Feature,
                    SoftwareId = 13,
                    TestId = 12,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                    End = DateTime.Now.AddDays(-6)
                },
                new
                {
                    Id = 15,
                    Title = "[DATA] Incorrect data calculations",
                    Description = "1. Perform data calculations\n2. Check if the calculated data is correct",
                    ReleaseId = 3,
                    IsRegression = false,
                    IsFixed = true,
                    CompletedReason = DefectCompletedReasonEnum.Fixed,
                    FixedOnVersion = "SW_1.0.2.6",
                    Created = DateTime.Now.AddDays(-6),
                    Status = DefectStatusEnum.Resolved,
                    Component = ComponentEnum.Data,
                    SoftwareId = 14,
                    TestId = 13,
                    UsersInvolvedEmails = "dzyzusek@gmail.com;wrk.mmarzec@gmail.com;",
                    End = DateTime.Now.AddDays(-5)
                }
                );

            modelBuilder.Entity<Feature>().HasMany(f => f.Tests).WithOne(t => t.Feature).HasForeignKey(t => t.FeatureId);
        }
    }
}
