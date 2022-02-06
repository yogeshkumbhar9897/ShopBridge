namespace ShopBridge.Models
{
    public class Response
    {
        public Response()
        {
                
        }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public dynamic Data { get; set; }

    }
}
