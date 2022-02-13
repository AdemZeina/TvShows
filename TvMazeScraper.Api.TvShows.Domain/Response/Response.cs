using System.Collections.Generic;

namespace TvMazeScraper.Api.TvShows.Domain.Response
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        public Response(bool success, List<string> errors, string message)
        {
            Succeeded = false;
            Message = message;
            Errors = errors;

        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public IList<string> Errors { get; set; }
        public string Message { get; set; }
    }
}
