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
            _services.UseSharePointSite(SharePointConfiguration.Configuration);
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
