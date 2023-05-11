using static SharePoint.Connector.Core.Business.Infrastructure.Helpers;

namespace SharePoint.Connector.Core.Business.Commands
{
    /// <summary>
    /// This interface define the methods that are used as a command in a SharePoint site.
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
        /// This function move a resource to the Recycled Bin of a site.
        /// </summary>
        /// <param name="endpoint">Resource path location.</param>
        /// <returns>Recycled resource unique identifier.</returns>
        Task<Guid> MoveToRecycledBinAsync(string endpoint);

        /// <summary>
        /// This function restore a resource from the Recycled Bin of a site.
        /// </summary>
        /// <param name="resourceId">Recycled Bin resource unique identifier.</param>
        /// <returns>Recycled resource restored flag.</returns>
        Task<bool> RestoreFromRecycledBinAsync(Guid resourceId);
    }
}
