namespace SharePoint.Connector.Core.Models
{
    public class SPSiteUsage
    {
        public string Bandwidth { get; set; } = string.Empty;

        public string DiscussionStorage { get; set; } = string.Empty;

        public string Hits { get; set; } = string.Empty;

        public string Storage { get; set; } = string.Empty;

        public double StoragePercentageUsed { get; set; } = double.MinValue;

        public string Visits { get; set; } = string.Empty;
    }
}
