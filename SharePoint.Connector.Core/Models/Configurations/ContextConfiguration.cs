namespace SharePoint.Connector.Core.Models.Configurations
{
    /// <summary>
    /// This class contains the definition of all the variables that will be used in for the 
    /// connection to Sharepoint throughth a REST API.
    /// </summary>
    public class ContextConfiguration
    {
        /** Authentication for sharepoint configuration. **/
        /// <summary>
        /// Get and set the authentication URL for Sharepoint.
        /// </summary>
        public string AuthenticationUrl { get; set; } = "";

        /// <summary>
        /// Get and set the Tenant unique identifier.
        /// </summary>
        public string TenantId { get; set; } = "";

        /// <summary>
        /// Get and set the Client unique identifier.
        /// </summary>
        public string ClientId { get; set; } = "";

        /// <summary>
        /// Get and set the Client Secret unique identifer.
        /// </summary>
        public string ClientSecret { get; set; } = "";

        /// <summary>
        /// Get and set the Grant type.
        /// </summary>
        public string GrantType { get; set; } = "";

        /// <summary>
        /// Get and set the Resource.
        /// </summary>
        public string Resource { get; set; } = "";

        /** Rest API to sharepoint site configuration **/
        /// <summary>
        /// Get and set the Site unique identifier.
        /// </summary>
        public string SharepointSiteId { get; set; } = "";

        /// <summary>
        /// Get and set the Site name.
        /// </summary>
        public string SharepointSiteName { get; set; } = "";

        /// <summary>
        /// Get and set the Sharepoint instance (organization sharepoint URL)
        /// </summary>
        public string SharepointInstanceUrl { get; set; } = "";

        /// <summary>
        /// Get and set the Sharepoint site URL.
        /// </summary>
        public string SharepointSiteUrl { get; set; } = "";

        /// <summary>
        /// Get and set the Site Relative URL.
        /// </summary>
        public string ServerRelativeUrl { get; set; } = "";
    }
}
