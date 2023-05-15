namespace SharePoint.Http.Connector.Core.UT
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
            _services.UseSharePointSite(SharePointConfiguration.Configuration);
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