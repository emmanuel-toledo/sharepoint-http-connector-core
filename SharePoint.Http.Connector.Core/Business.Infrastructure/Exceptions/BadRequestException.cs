namespace Sharepoint.Http.Data.Connector.Business.Infrastructure.Exceptions
{
    /// <summary>
    /// This class is a custom exception for 'Bad request' exception when exists an interaction with a Sharepoint site.
    /// </summary>
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException() : base() { }

        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
    }
}
