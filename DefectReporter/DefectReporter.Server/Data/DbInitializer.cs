namespace DefectReporter.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DefectReporterContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
