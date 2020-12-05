using System;
using System.Collections.Generic;
using BasketAPI.Data.Entities;

namespace BasketAPI.Models.ViewModel
{
    public class GetBasketResponse
    {
        public IEnumerable<BasketItem> BasketItems { get; set; }
        public int StatusCode { get; set; } = 200;
        public bool IsSuccess => StatusCode >= 200 && StatusCode < 400;

    }
}
