using System;
namespace BasketAPI.Models.ViewModel
{
    public class AddBasketResponse
    {
      public int StatusCode { get; set; } = 200;
      public bool IsSuccess => StatusCode >= 200 && StatusCode < 400;
    }
}
