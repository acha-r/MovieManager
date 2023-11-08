using MovieManager.Enums;
using Newtonsoft.Json;

namespace MovieManager.Services.Handler
{
    public class ErrorResponse
    {
        public ResponseStatus Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
