using SharePoint.Http.Connector.Core.Microsoft.Extensions.SharePoint;
using SharePoint.Http.Connector.Core.Models.Configurations;

namespace SharePoint.Http.Connector.Core.Business.Configurations
{
    /// <summary>
    /// This interface defines the configuration methods and properties to access to SharePoint API.
    /// </summary>
    public interface ISharePointConfiguration
    {
        /// <summary>
        /// Throw SharePoint exceptions.
        /// </summary>
        bool ThrowExceptions { get; }

        /// <summary>
        /// Selected SharePoint configuration.
        /// </summary>
        SPContextConfiguration? Configuration { get; }

        /// <summary>
        /// Set selected SharePoint configuration object.
        /// </summary>
        /// <param name="configuration">SharePoint context configuration object.</param>
        void AddConfiguration(SPContextConfiguration configuration);

        /// <summary>
        /// Function to get server relative URL from selected configuration.
        /// </summary>
        /// <returns>Server relative URL string.</returns>
        /// <exception cref="NullReferenceException">No SharePoint site configured</exception>
        /// <exception cref="NotSupportedException">Not valid SharePoint server relative URL.</exception>
        string GetServerRelativeURL();
    }

    /// <summary>
    /// This class implements the configuration methods and properties to access to SharePoint API.
    /// </summary>
    public class SharePointConfiguration : ISharePointConfiguration
    {
        /// <summary>
        /// Get and set selected SharePoint configuration.
        /// </summary>
        private SPContextConfiguration? _configuration { get; set; } = null;

        /// <summary>
        /// Get and set throw SharePoint exceptions flag.
        /// </summary>
        private bool _throwExceptions { get; set; } = true;

        public SharePointConfiguration() { }

        public SharePointConfiguration(SPContextConfiguration configuration)
            => this._configuration = configuration;

        public SharePointConfiguration(SPContextConfiguration configuration, bool throwExceptions)
        {
            this._configuration = configuration;
            this._throwExceptions = throwExceptions;
        }

        /// <summary>
        /// Throw SharePoint exceptions.
        /// </summary>
        public bool ThrowExceptions { get => this._throwExceptions; }

        /// <summary>
        /// Get selected SharePoint configuration.
        /// </summary>
        public SPContextConfiguration? Configuration { get => this._configuration; }

        /// <summary>
        /// Set main SharePoint configuration object.
        /// </summary>
        /// <param name="configuration">SharePoint context configuration object.</param>
        public void AddConfiguration(SPContextConfiguration configuration)
            => this._configuration = configuration;

        /// <summary>
        /// Set throw exceptions flag.
        /// </summary>
        /// <param name="throwExceptions">Throw exceptions flag.</param>
        public void SetThrowExceptions(bool throwExceptions)
            => this._throwExceptions = throwExceptions;

        /// <summary>
        /// Function to get server relative URL from selected configuration.
        /// </summary>
        /// <returns>Server relative URL string.</returns>
        /// <exception cref="NullReferenceException">No SharePoint site configured</exception>
        /// <exception cref="NotSupportedException">Not valid SharePoint server relative URL.</exception>
        public string GetServerRelativeURL()
        {
            if(this._configuration is null) throw new NullReferenceException("SharePoint site configuration were not defined.");
            string url = this._configuration.GetRelativeURL();
            if (string.IsNullOrEmpty(url))
                throw new NotSupportedException("SharePoint site URL is not correctly defined for this service.");
            return url;
        }
    }
}
