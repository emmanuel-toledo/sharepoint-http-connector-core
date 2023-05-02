namespace SharePoint.Connector.Core.Models
{
    /// <summary>
    /// This class contains the main information from a Sharepoint file. 
    /// </summary>
    public class SharePointFile
    {
        /// <summary>
        /// Get and set Unique identifier.
        /// </summary>
        public Guid UniqueId { get; set; }

        /// <summary>
        /// Get and set Check in comment.
        /// </summary>
        public string CheckInComment { get; set; }

        /// <summary>
        /// Get and set Content tag.
        /// </summary>
        public string ContentTag { get; set; }

        /// <summary>
        /// Get and set existence.
        /// </summary>
        public bool Exists { get; set; }

        /// <summary>
        /// Get and set length.
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// Get and set level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Get and set Major version.
        /// </summary>
        public int MajorVersion { get; set; }

        /// <summary>
        /// Get and set minor version.
        /// </summary>
        public int MinorVersion { get; set; }

        /// <summary>
        /// Get and set Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get and set Server relative URL.
        /// </summary>
        public string ServerRelativeUrl { get; set; }

        /// <summary>
        /// Get and set Created on datetime.
        /// </summary>
        public DateTime TimeCreated { get; set; }

        /// <summary>
        /// Get and set Modified on datetime.
        /// </summary>
        public DateTime TimeLastModified { get; set; }

        /// <summary>
        /// Get and set Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get and set UI version.
        /// </summary>
        public int UIVersion { get; set; }
    }
}
