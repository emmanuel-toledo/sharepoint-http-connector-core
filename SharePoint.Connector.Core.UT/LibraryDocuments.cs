namespace SharePoint.Connector.Core.UT
{
    [TestClass]
    public class LibraryDocuments
    {
        private IServiceProvider _provider;

        private IServiceCollection _services; 

        [TestInitialize()] 
        public void Initialize()
        {
            _services = new ServiceCollection();
            _services.UseSharePointSite(new ContextConfiguration()
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
        public async Task Get_Lirarby_Documents_Collection()
        {
            var sharepointContext = _provider.GetService<ISharePointContext>()!;
            var response = await sharepointContext.LibraryDocumentsAsync();
            Assert.IsNotNull(response);
        }
    }
}