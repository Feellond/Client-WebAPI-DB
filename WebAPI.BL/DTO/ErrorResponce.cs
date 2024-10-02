namespace WebAPI.BL.DTO
{
    public class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;

        public ErrorResponse(string message) { 
            Message = message;
        }
    }
}
