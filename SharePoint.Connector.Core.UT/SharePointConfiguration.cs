namespace SharePoint.Connector.Core.UT
{
    public static class SharePointConfiguration
    {
        public static SPContextConfiguration Configuration 
        {
            get => new()
            {
                Id = Guid.NewGuid(),
                Name = "Site name",
                TenantId = "00000000-0000-0000-0000-000000000000",
                ClientId = "00000000-0000-0000-0000-000000000000@00000000-0000-0000-0000-000000000000",
                ClientSecret = "Your Client Secret",
                SharePointSiteURL = "https://contoso.sharepoint.com/sites/contoso-site/"
            };
        }
    }
}
