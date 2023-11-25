namespace Gent.Services.ProductAPI.Application.DTOs
{
    public class BaseResponse
    {
        public bool HasSucceded { get; set; } = true;
        public object? Result { get; set; }

        public BaseErrorResponse? ErrorResponse { get; set; }
    }

    public class BaseErrorResponse
    {
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
