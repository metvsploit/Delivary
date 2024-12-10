namespace Delivary.Application.Exceptions
{
    public class AppException : Exception
    {
        public string ResponseMessage { get; set; }
        public string Message { get; set; }

        public AppException(string message, string responseMsg) : base(message)
        {
            ResponseMessage = responseMsg;
            Message = message;
        }
    }
}
