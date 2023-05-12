namespace Sharepoint.Http.Data.Connector.Business.Infrastructure.Exceptions
{
    /// <summary>
    /// This class is a custom exception for 'Unauthorized' exception when exists an interaction with a Sharepoint site.
    /// </summary>
    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base() { }

        public UnauthorizedException(string message) : base(message) { }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException) { }

        public UnauthorizedException(object key) : base($"The connection '{ key }' is not authorized.") { }
    }
}
