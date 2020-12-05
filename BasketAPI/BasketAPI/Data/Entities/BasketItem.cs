using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasketAPI.Data.Entities
{
    [Table("BasketItem")]
    public class BasketItem : BaseEntity<int>
    {
        public string UserName { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
