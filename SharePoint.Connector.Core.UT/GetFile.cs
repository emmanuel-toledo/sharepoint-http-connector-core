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
            _services.UseSharePointSite(SharePointConfiguration.Configuration);
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
