using System;
using System.Net;

namespace VirtualMind.Core.Exceptions
{
    public class BussinessException : Exception
    {

        public BussinessException(HttpStatusCode statusCode, string message, ExceptionCode exceptionCode)
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.ExceptionCode = exceptionCode;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public ExceptionCode ExceptionCode { get; set; }

    }
}
