using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace BOFI.API.Web.Infraestructure
{
    public static class ResponseHandlingExtensions
    {
        public static HttpResponseMessage SendResponse(this HttpRequestMessage request, HttpStatusCode statusCode, ResponseBuilder responseBuilder)
        {
            return request.CreateResponse(statusCode, responseBuilder.Result());
        }

        public static HttpResponseMessage SendErrorResponse(this HttpRequestMessage request, List<string> validation)
        {
            var responseBuilder = new ResponseBuilder("failed");
            responseBuilder.SetErrors(validation);
            return request.SendResponse(HttpStatusCode.BadRequest, responseBuilder);
        }
    }
}