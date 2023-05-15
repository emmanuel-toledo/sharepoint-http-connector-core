namespace SharePoint.Http.Connector.Core.UT
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
            _services.UseSharePointSite(SharePointConfiguration.Configuration);
            _provider = _services.BuildServiceProvider();
        }

        [TestMethod]
        public async Task Get_Lirarby_Documents_Collection()
        {
            var sharepointContext = _provider.GetService<ISharePointContext>()!;
            var response = await sharepointContext.GetLibraryDocumentsAsync();
            Assert.IsNotNull(response);
        }
    }
}