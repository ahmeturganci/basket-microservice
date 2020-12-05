using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasketAPI.Data.Entities;
using BasketAPI.Models.ViewModel;

namespace BasketAPI.Services.Implementations
{
    public interface IBasketService
    {
        Task<GetBasketResponse> GetBasketsAsync();
        Task<AddBasketResponse> AddBasketsAsync(AddBasketRequest request);
        Task<GetBasketByUserNameResponse> GetBasketsByUserNameAsync(GetBasketByUserNameRequest request);
    }
}
