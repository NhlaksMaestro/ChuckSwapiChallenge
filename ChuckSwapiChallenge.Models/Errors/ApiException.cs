using System;
using System.Net;
using System.Runtime.Serialization;

namespace ChuckSwapiChallenge.Models.Errors
{
    [Serializable]
    public class ApiException : Exception
    {
        public HttpStatusCode _statusCode { get; set; }
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ApiException()
        {
        }

        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, HttpStatusCode statusCode) : base(message)
        {
            _statusCode = statusCode;
        }

        public ApiException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ApiException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
