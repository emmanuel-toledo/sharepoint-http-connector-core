namespace SharePoint.Connector.Core.Models
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
        /// Get and set Server relative URL.
        /// </summary>
        public string ServerRelativeUrl { get; set; }

        /// <summary>
        /// Get and set Created on date time.
        /// </summary>
        public DateTime TimeCreated { get; set; }

        /// <summary>
        /// Get and set Modified on date time.
        /// </summary>
        public DateTime TimeLastModified { get; set; }
    }
}
