using System;
using BasketAPI.Data.Entities;

namespace BasketAPI.Models.ViewModel
{
    public class GetBasketByUserNameResponse
    {
        public BasketItem Basket { get; set; }
        public int StatusCode { get; set; } = 200;
        public bool IsSuccess => StatusCode >= 200 && StatusCode < 400;
    }
}
