using SharePoint.Connector.Core.Models;
using SharePoint.Connector.Core.Microsoft.Extensions.DependencyInjection;

namespace SharePoint.Connector.Core.UT
{
    [TestClass]
    public class GetFile
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
            }, false);
            _provider = _services.BuildServiceProvider();
            _context = _provider.GetService<ISharePointContext>()!;
        }

        [TestMethod]
        [DataRow("Shared Documents", "Documento.pdf")]
        public async Task Get_File(string relativeURL, string resourceName)
        {
            var fileInformation = await Get_File_Information(relativeURL, resourceName);
            var fileContent = await Get_File_Content(relativeURL, resourceName);
            var base64 = fileContent.ToBase64();
            Assert.IsNotNull(fileInformation);
            Assert.AreEqual(true, (fileContent != null && fileContent.Length != 0));
            Assert.AreNotEqual(string.Empty, base64);
        }

        public async Task<byte[]?> Get_File_Content(string relativeURL, string resourceName)
        {
            var response = await _context.GetFileContentAsync(relativeURL, resourceName);
            return response;
        }

        public async Task<SPFile?> Get_File_Information(string relativeURL, string resourceName)
        {
            var response = await _context.GetFileAsync(relativeURL, resourceName);
            return response;
        }
    }
}
