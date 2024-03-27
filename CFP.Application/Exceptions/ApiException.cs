using System.Net;

namespace CFP.Application.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; init; }
        public string Type { get; init; }   
        public string Message { get; init; }

        public ApiException(int statusCode, string type, string message)
        {
            StatusCode = statusCode;
            Type = type;
            Message = message;
        }

        public ApiException(HttpStatusCode statusCode, string type, string message)
        {
            StatusCode = (int)statusCode;
            Type = type;
            Message = message;
        }
    }
}
