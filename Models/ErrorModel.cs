namespace MovieTinder_API.Models
{
    public class ErrorModel
    {
        public ErrorModel() 
        {
            Code = string.Empty;
            Message= string.Empty;
        }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
