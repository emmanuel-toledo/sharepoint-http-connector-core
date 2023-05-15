namespace SharePoint.Http.Connector.Core.Models
{
    /// <summary>
    /// This class contains the main information from a Sharepoint folder.
    /// </summary>
    public class SPFolder
    {
        /// <summary>
        /// Get and set folder unique identifier.
        /// </summary>
        public Guid UniqueId { get; set; }

        /// <summary>
        /// Get and set folder name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get and set item count from folder.
        /// </summary>
        public int ItemCount { get; set; }

        /// <summary>
        /// Get and set existence of folder.
        /// </summary>
        public bool Exists { get; set; }

        /// <summary>
        /// Get and set is WOPI enabled.
        /// </summary>
        public bool IsWOPIEnabled { get; set; }

        /// <summary>
        /// Get and set prog ID.
        /// </summary>
        public string? ProgID { get; set; }

        /// <summary>
        /// Get and set server relative URL.
        /// </summary>
        public string ServerRelativeURL { get; set; }

        /// <summary>
        /// Get and set created on date time.
        /// </summary>
        public DateTime TimeCreated { get; set; }

        /// <summary>
        /// Get and set modified on date time.
        /// </summary>
        public DateTime TimeLastModified { get; set; }

        /// <summary>
        /// Get and set welcome page.
        /// </summary>
        public string WelcomePage { get; set; }
    }
}
