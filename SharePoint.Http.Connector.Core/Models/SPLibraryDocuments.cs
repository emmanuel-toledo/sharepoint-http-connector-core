namespace SharePoint.Http.Connector.Core.Models
{
    /// <summary>
    /// This class represents a Library Documents in a SharePoint site.
    /// </summary>
    public class SPLibraryDocuments
    {
        /// <summary>
        /// Get and set unique id.
        /// </summary>
        public Guid UniqueId { get; set; }

        /// <summary>
        /// Get and set name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Get and set exists.
        /// </summary>
        public bool Exists { get; set; }

        /// <summary>
        /// Get and set item count.
        /// </summary>
        public int ItemsCount { get; set; }

        /// <summary>
        /// Get and set server relative URL.
        /// </summary>
        public string? ServerRelativeURL { get; set; }

        /// <summary>
        /// Get and set time created.
        /// </summary>
        public DateTime TimeCreated { get; set; }

        /// <summary>
        /// Get and set time last modified.
        /// </summary>
        public DateTime TimeLastModified { get; set; }

        /// <summary>
        /// Get and set is WOPI enable.
        /// </summary>
        public bool IsWOPIEnable { get; set; }

        /// <summary>
        /// Get and set prog id.
        /// </summary>
        public string? ProgID { get; set; }

        /// <summary>
        /// Get and set welcome page.
        /// </summary>
        public string? WelcomePage { get; set; }
    }
}
