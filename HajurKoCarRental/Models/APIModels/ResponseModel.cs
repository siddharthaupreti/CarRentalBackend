using System.Net;

namespace EMusic.Models.APIModels
{
    public class ResponseModel
    {
        public HttpStatusCode status { get; set; }
        public string? message { get; set; }
        public dynamic? data { get; set; }
    }
}
