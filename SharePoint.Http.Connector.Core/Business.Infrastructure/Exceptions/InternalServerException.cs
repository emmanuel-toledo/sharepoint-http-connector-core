namespace Sharepoint.Http.Data.Connector.Business.Infrastructure.Exceptions
{
    /// <summary>
    /// This class is a custom exception for 'Internal server error' exception when exists an interaction with a Sharepoint site.
    /// </summary>
    [Serializable]
    public class InternalServerException : Exception
    {
        public InternalServerException() : base() { }

        public InternalServerException(string message) : base(message) { }

        public InternalServerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
