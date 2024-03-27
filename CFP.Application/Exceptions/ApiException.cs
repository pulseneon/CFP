using System.Net;

namespace CFP.Application.Exceptions
{
    public class CFPException : Exception
    {
        public int StatusCode { get; init; }
        public string Type { get; init; }   
        public string Message { get; init; }

        public CFPException(int statusCode, string type, string message)
        {
            StatusCode = statusCode;
            Type = type;
            Message = message;
        }

        public CFPException(HttpStatusCode statusCode, string type, string message)
        {
            StatusCode = (int)statusCode;
            Type = type;
            Message = message;
        }
    }
}
