namespace ConsoleWebAPI.Models
{
    public class ResponseError
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;  
    }
}
