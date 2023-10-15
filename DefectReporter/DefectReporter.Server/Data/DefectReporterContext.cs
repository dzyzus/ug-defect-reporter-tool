namespace DefectReporter.Server.Data
{
    #region Usings

    using DefectReporter.Shared.Models;
    using Microsoft.EntityFrameworkCore;
    
    #endregion

    public class DefectReporterContext : DbContext
    {
        /// <summary>
        /// The defect reporter context constructor.
        /// </summary>
        /// <param name="options">
        /// The db context options.
        /// </param>
        public DefectReporterContext(DbContextOptions<DefectReporterContext> options) : base(options)
        {
        }

        public DbSet<Defect> Defects { get; set; }
    }
}
