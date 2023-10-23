namespace DefectReporter.Server.Data
{
    #region Usings

    using DefectReporter.Shared.Models;
    using Microsoft.EntityFrameworkCore;
    
    #endregion

    public class DefectReporterContext : DbContext
    {
        /// <summary>
        /// The db set of defects.
        /// </summary>
        public DbSet<Defect> Defects { get; set; }

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
            modelBuilder.Entity<Comment>()
                .HasOne(p => p.Defect)
                .WithMany(c => c.Comments)
                .HasForeignKey(p => p.DefectId);
        }

    }
}
