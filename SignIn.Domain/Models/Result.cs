

using SignIn.Domain.Entities;

namespace SignIn.Presentation.Models
{
    public class Result
    {
        public Result(object data)
        {
            Success = true;
            Message = null;
            Data = data;
        }
        public Result(string message)
        {
            Success = false;
            Message = message;
            Data = null;
        }

        public bool Success { get; }
        public object Data { get; }
        public string? Message { get; }
    }
}