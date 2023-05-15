namespace SharePoint.Http.Connector.Core.UT
{
    [TestClass]
    public class SiteUsage
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
        public async Task Get_Site_Usage()
        {
            var response = await _context.GetSiteUsageAsync();
            Assert.IsNotNull(response);
        }
    }
}
