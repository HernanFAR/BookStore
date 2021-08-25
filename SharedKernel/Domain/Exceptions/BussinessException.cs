using System;
using System.Net;

namespace SharedKernel.Domain.Exceptions
{
    public class BussinessException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public BussinessException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public static BussinessException NotAcceptableWithMessage(string message)
        {
            return new BussinessException(message, HttpStatusCode.NotAcceptable);
        }

        public static BussinessException NotFoundWithMessage(string message)
        {
            return new BussinessException(message, HttpStatusCode.NotFound);
        }

        public static BussinessException UnprocessableEntityWithMessage(string message)
        {
            return new BussinessException(message, HttpStatusCode.UnprocessableEntity);
        }

    }
}
