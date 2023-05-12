using SharePoint.Connector.Core.Models;
using SharePoint.Connector.Core.Microsoft.Extensions.DependencyInjection;

namespace SharePoint.Connector.Core.UT
{
    [TestClass]
    public class RecycleBinResource
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
        [DataRow("Shared Documents/test-folder/Documento.pdf")]
        [DataRow("Shared Documents/Remove")]
        public async Task Move_Resource_To_Recycle_Bin(string relativeURL)
        {
            var resourceId = await _context.MoveResourceToRecycleBinAsync(relativeURL);
            var resource = await Get_Recycle_Bin_Resource(resourceId);
            var restored = await Restore_Recycle_Bin_Resource(resourceId);
            Assert.AreNotEqual(Guid.Empty, resourceId);
            Assert.IsNotNull(resource);
            Assert.AreEqual(true, restored);
        }

        public async Task<SPRecycleResource?> Get_Recycle_Bin_Resource(Guid resourceId)
        {
            var response = await _context.GetRecycleBinResourceByIdAsync(resourceId);
            return response;
        }

        public async Task<bool> Restore_Recycle_Bin_Resource(Guid resourceId)
        {
            var response = await _context.RestoreRecycleBinResourceByIdAsync(resourceId);
            return response;
        }
    }
}
