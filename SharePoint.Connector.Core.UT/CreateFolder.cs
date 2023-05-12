using SharePoint.Connector.Core.Microsoft.Extensions.DependencyInjection;

namespace SharePoint.Connector.Core.UT
{
    [TestClass]
    public class CreateFolder
    {
        private IServiceProvider _provider;

        private IServiceCollection _services;

        private ISharePointContext _context;

        [TestInitialize()]
        public void Initialize()
        {
            _services = new ServiceCollection();
            _services.UseSharePointSite(new SPContextConfiguration()
            {
                Id = Guid.NewGuid(),
                Name = "Test Site",
                TenantId = "346a1d1d-e75b-4753-902b-74ed60ae77a1",
                ClientId = "4a929590-75e1-4fda-b9d2-9f5acbf8251e@346a1d1d-e75b-4753-902b-74ed60ae77a1",
                ClientSecret = "CqUv/BdSw0nLfqccLoPiFvQJDAbfXMvIoPpn+tw54rY=",
                SharePointSiteURL = "https://laureatelatammx.sharepoint.com/sites/uvm-expediente-digital-dev/"
            });
            _provider = _services.BuildServiceProvider();
            _context = _provider.GetService<ISharePointContext>()!;
        }

        [TestMethod]
        [DataRow("Shared Documents", "Documentos-Test")]
        [DataRow("Shared Documents/Documentos-Test-2", "")]
        public async Task Create_Folder(string relativeURL, string resourceName)
        {
            var folder = await _context.CreateFolderAsync(relativeURL, resourceName);
            Assert.IsNotNull(folder);
        }
    }
}
