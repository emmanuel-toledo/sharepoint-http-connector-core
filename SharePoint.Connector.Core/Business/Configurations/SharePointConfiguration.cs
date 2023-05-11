using SharePoint.Connector.Core.Models.Configurations;

namespace SharePoint.Connector.Core.Business.Configurations
{
    public interface ISharePointConfiguration
    {
        IList<ContextConfiguration> Configurations { get; }

        void AddConfiguration(ContextConfiguration configuration);

        void AddConfigurations(IList<ContextConfiguration> configurations);
    }

    public class SharePointConfiguration : ISharePointConfiguration
    {
        public SharePointConfiguration() { }

        public SharePointConfiguration(ContextConfiguration configuration)
            => AddConfiguration(configuration);

        public SharePointConfiguration(IList<ContextConfiguration> configurations)
            => AddConfigurations(configurations);

        public IList<ContextConfiguration> Configurations { get; set; } = new List<ContextConfiguration>();

        public void AddConfiguration(ContextConfiguration configuration)
            => Configurations.Add(configuration);

        public void AddConfigurations(IList<ContextConfiguration> configurations)
            => Configurations = configurations;
    }
}
