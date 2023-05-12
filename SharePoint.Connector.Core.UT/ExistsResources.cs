using SharePoint.Connector.Core.Microsoft.Extensions.DependencyInjection;

namespace SharePoint.Connector.Core.UT
{
    [TestClass]
    public class ExistsResources
    {
        private IServiceProvider _provider;

        private IServiceCollection _services; 

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
        }

        [TestMethod]
        [DataRow("Shared Documents/test-folder", "")]
        [DataRow("Shared Documents/test-folder", "test-folder-2")]
        public async Task Exists_Resource(string relativeURL, string fileName)
        {
            var sharepointContext = _provider.GetService<ISharePointContext>()!;
            var response = false;
            if(string.IsNullOrEmpty(fileName))
                response = await sharepointContext.ExistsResourceAsync(relativeURL);
            else
                response = await sharepointContext.ExistsResourceAsync(relativeURL, fileName);
            Assert.AreEqual(true, response);
        }

        [TestMethod]
        [DataRow("MyDocuments/test-folder", "")]
        [DataRow("MyDocuments/test-folder", "test-folder-2")]
        public async Task Does_Not_Exists_Resource(string relativeURL, string fileName)
        {
            var sharepointContext = _provider.GetService<ISharePointContext>()!;
            var response = true;
            if (string.IsNullOrEmpty(fileName))
                response = await sharepointContext.ExistsResourceAsync(relativeURL);
            else
                response = await sharepointContext.ExistsResourceAsync(relativeURL, fileName);
            Assert.AreEqual(false, response);
        }
    }
}