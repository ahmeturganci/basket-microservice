using System;
namespace BasketAPI.Models.ViewModel
{
    public class AddBasketRequest
    {
        public string UserName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
