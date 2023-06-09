﻿namespace SharePoint.Http.Connector.Core.UT
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
            _services.UseSharePointSite(SharePointConfiguration.Configuration);
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
