namespace SharePoint.Http.Connector.Core.Models
{
    /// <summary>
    /// This class contains the properties of a site usage in SharePoint.
    /// </summary>
    public class SPSiteUsage
    {
        /// <summary>
        /// Get and set band width.
        /// </summary>
        public string Bandwidth { get; set; } = string.Empty;

        /// <summary>
        /// Get and set discussion storage
        /// </summary>
        public string DiscussionStorage { get; set; } = string.Empty;

        /// <summary>
        /// Get and set hits.
        /// </summary>
        public string Hits { get; set; } = string.Empty;

        /// <summary>
        /// Get and set storage.
        /// </summary>
        public string Storage { get; set; } = string.Empty;

        /// <summary>
        /// Get and set storage percentage used
        /// </summary>
        public double StoragePercentageUsed { get; set; } = double.MinValue;

        /// <summary>
        /// Get and set visits.
        /// </summary>
        public string Visits { get; set; } = string.Empty;
    }
}
