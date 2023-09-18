using System.Net;

namespace IntegradorSofttekImanol.Infrastructure
{
    public class ApiErrorResponse
    {

        public HttpStatusCode StatusCode { get; set; }

        public List<ResponseError> Error { get; set; }


        public class ResponseError
        {
            public string Error { get; set; }

            public string? Data { get; set; }
        }
    }
}
