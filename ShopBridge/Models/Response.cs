using System.Diagnostics.CodeAnalysis;

namespace ShopBridge.Models
{
    [ExcludeFromCodeCoverage]
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
