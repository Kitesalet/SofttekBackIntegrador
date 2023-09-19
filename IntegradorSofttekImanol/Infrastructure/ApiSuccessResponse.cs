using System.Net;

namespace IntegradorSofttekImanol.Infrastructure
{
    public class ApiSuccessResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public object? Data { get; set; }

    }
}
