namespace SharePoint.Connector.Core.Models
{
    /// <summary>
    /// This class contains the main information of a resource deleted in recycle bin in sharepoint site.
    /// </summary>
    public class SPRecycleResource
    {
        /// <summary>
        /// Get and set the Resource unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Get and set the author email.
        /// </summary>
        public string AuthorEmail { get; set; }

        /// <summary>
        /// Get and set the author name.
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Get and set the directory path of the resource.
        /// </summary>
        public string DirName { get; set; }

        /// <summary>
        /// Get and set the resource title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get and set the resource size.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Get and set the item type.
        /// </summary>
        public int ItemType { get; set; }

        /// <summary>
        /// Get and set the item state.
        /// </summary>
        public int ItemState { get; set; }

        /// <summary>
        /// Get and set the name of user who delete the resource.
        /// </summary>
        public string DeteleteByName { get; set; }

        /// <summary>
        /// Get and set email who delete the resource.
        /// </summary>
        public string DeletedByEmail { get; set; }

        /// <summary>
        /// Get and set the deleted date.
        /// </summary>
        public DateTime DeletedDate { get; set; }

        /// <summary>
        /// Get and set the deleted date formatter to local date time.
        /// </summary>
        public string DeletedDateLocalFormatted { get; set; }
    }
}
