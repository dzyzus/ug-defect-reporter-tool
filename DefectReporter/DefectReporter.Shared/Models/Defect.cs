namespace DefectReporter.Shared.Models
{
    /// <summary>
    /// The defect - article model.
    /// </summary>
    public class Defect
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
