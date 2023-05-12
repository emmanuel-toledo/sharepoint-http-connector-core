using SharePoint.Connector.Core.Models;
using static SharePoint.Connector.Core.Business.Infrastructure.Helpers;

namespace SharePoint.Connector.Core.Business.Commands
{
    /// <summary>
    /// This interface defines the methods that are used as a command in a SharePoint site.
    /// </summary>
    public interface ISharePointCommands
    {
        /// <summary>
        /// Function to delete a SharePoint Resouce using RelativeURL.
        /// </summary>
        /// <param name="relativeURL">Resource's relative URL.</param>
        /// <param name="resourceType">Resource type</param>
        /// <returns>Success deleted</returns>
        Task<bool> DeleteResourceAsync(string relativeURL, ResourceType resourceType);

        /// <summary>
        /// Function to delete a SharePoint Resouce using RelativeURL.
        /// </summary>
        /// <param name="relativeURL">Resource's relative URL.</param>
        /// /// <param name="resourceName">Resource's name.</param>
        /// <param name="resourceType">Resource type</param>
        /// <returns>Success deleted</returns>
        Task<bool> DeleteResourceAsync(string relativeURL, string resourceName, ResourceType resourceType);

        /// <summary>
        /// This function move a resource to the Recycle Bin of a site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative URL.</param>
        /// <returns>Recycle resource unique identifier.</returns>
        Task<Guid> MoveResourceToRecycleBinAsync(string relativeURL);

        /// <summary>
        /// This function restore a resource from the Recycle Bin of a site.
        /// </summary>
        /// <param name="resourceId">Recycle Bin resource unique identifier.</param>
        /// <returns>Recycle resource restored flag.</returns>
        Task<bool> RestoreRecycleBinResourceByIdAsync(Guid resourceId);

        /// <summary>
        /// Function to create a new folder in SharePoint.
        /// </summary>
        /// <param name="relativeURL">Folder relative URL location.</param>
        /// <returns>SharePoint folder object.</returns>
        Task<SPFolder?> CreateFolderAsync(string relativeURL);

        /// <summary>
        /// This method upload a file in a SharePoint site.
        /// </summary>
        /// <param name="relativeURL">Resource's relative path location.</param>
        /// <param name="resourceName">Resource's name.</param>
        /// <param name="content">Resource's content.</param>
        /// <returns>SharePoint file object.</returns>
        Task<SPFile?> UploadFileAsync(string relativeURL, string resourceName, byte[] content);
    }
}
