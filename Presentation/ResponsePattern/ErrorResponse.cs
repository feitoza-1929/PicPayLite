using FluentResults;
using PicPayLite.Domain.Errors;

namespace PicPayLite.Presentation.ResponsePattern
{
    public class ErrorResponse
    {
        public string? Code { get; private set; } = string.Empty;
        public string Message { get; private set; } = string.Empty;

        private ErrorResponse(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public static ErrorResponse Create(IError error)
        {
            object code;
            error.Metadata.TryGetValue("Code", out code);

            return new ErrorResponse(code.ToString(), error.Message);
        }
    }
}
