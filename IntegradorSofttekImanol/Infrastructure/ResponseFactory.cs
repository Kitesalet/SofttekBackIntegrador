using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace IntegradorSofttekImanol.Infrastructure
{
    public static class ResponseFactory
    {
        public static IActionResult CreateSuccessResponse(HttpStatusCode statusCode, object? data)
        {
            var response = new ApiSuccessResponse()
            {
                StatusCode = statusCode
            };

            return new ObjectResult(response)
            {
                StatusCode = (int?)statusCode,
            };
        }

        public static IActionResult CreateErrorResponse(HttpStatusCode statusCode, string[] errors)
        {
            var response = new ApiErrorResponse()
            {
                StatusCode = statusCode,
                Error = new List<ApiErrorResponse.ResponseError>()
            };

            foreach(var error in errors)
            {
                response.Error.Add(new ApiErrorResponse.ResponseError() { Error = error });
            }

            return new ObjectResult(response)
            {
                StatusCode = (int?)statusCode,
            };
        }
    }
}
