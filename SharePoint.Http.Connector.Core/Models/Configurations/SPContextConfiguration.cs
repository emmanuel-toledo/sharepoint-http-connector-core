namespace SharePoint.Http.Connector.Core.Models.Configurations
{
    /// <summary>
    /// This class contains the Context Configuration to create a new instance connection to the specific site.
    /// </summary>
    public class SPContextConfiguration
    {
        /// <summary>
        /// Get and Set Unique identifier.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Get and Set Name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Get and Set Tenant unique identifier.
        /// </summary>
        public string TenantId { get; set; } = string.Empty;

        /// <summary>
        /// Get and Set Client unique identifier.
        /// </summary>
        public string ClientId { get; set; } = string.Empty;

        /// <summary>
        /// Get and Set Client secret.
        /// </summary>
        public string ClientSecret { get; set; } = string.Empty;

        /// <summary>
        /// Get and Set Server relative URL.
        /// </summary>
        //public string ServerRelativeURL { get; set; } = string.Empty;

        /// <summary>
        /// Get and Set SharePoint site URL.
        /// </summary>
        public string SharePointSiteURL { get; set; } = string.Empty;
    }
}
