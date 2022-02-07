using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace ShopBridge.Models
{
    [ExcludeFromCodeCoverage]
    public class Product
    {
        public int Id { get; set; }
        public string PName { get; set; }
        public string PDescription { get; set; }
        public float PPrice { get; set; }
        public int PQuantity { get; set; }
    }
}
