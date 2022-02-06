using Newtonsoft.Json;

namespace ShopBridge.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string PName { get; set; }
        public string PDescription { get; set; }
        public float PPrice { get; set; }
        public int PQuantity { get; set; }
    }
}
