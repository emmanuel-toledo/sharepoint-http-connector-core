using SharePoint.Connector.Core.Microsoft.Extensions.DependencyInjection;

namespace SharePoint.Connector.Core.UT
{
    [TestClass]
    public class DeleteResources
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
        public async Task Delete_Resources()
        {
            var result1 = await Delete_File_Resource("Shared Documents/030002721-01", "Documento.docx");
            var result2 = await Delete_File_Resource_RelativeURL("Shared Documents/030002721-01/Documento1.docx");
            var result3 = await Delete_Folder_Resource("Shared Documents/030002721-01");
            Assert.AreEqual(true, (result1 && result2 && result3));
        }

        public async Task<bool> Delete_File_Resource(string relativeURL, string resourceName)
        {
            var sharepointContext = _provider.GetService<ISharePointContext>()!;
            var response = await sharepointContext.DeleteFileAsync(relativeURL, resourceName);
            return response;
        }

        public async Task<bool> Delete_File_Resource_RelativeURL(string relativeURL)
        {
            var sharepointContext = _provider.GetService<ISharePointContext>()!;
            var response = await sharepointContext.DeleteFileAsync(relativeURL);
            return response;
        }

        public async Task<bool> Delete_Folder_Resource(string relativeURL)
        {
            var sharepointContext = _provider.GetService<ISharePointContext>()!;
            var response = await sharepointContext.DeleteFolderAsync(relativeURL);
            return response;
        }
    }
}
