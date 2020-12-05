using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BasketAPI.Data.Entities;
using BasketAPI.Models.ViewModel;
using BasketAPI.Repository.Implementations;
using BasketAPI.Services.Implementations;

namespace BasketAPI.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketService;


        public BasketService(IBasketRepository basketService)
        {
            _basketService = basketService;
        }

        public async Task<AddBasketResponse> AddBasketsAsync(AddBasketRequest request)
        {
            var response = new AddBasketResponse();

            BasketItem entity = new BasketItem()
            {
                UserName = request.UserName,
                Quantity = request.Quantity,
                Color = request.Color,
                Price = request.Price,
                ProductId = request.ProductId,
                ProductName = request.ProductName
            };

            bool status = await _basketService.AddBasketsAsync(entity);

            if (status)
            {
                response.StatusCode = (int)HttpStatusCode.Created;
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return response;

        }

        public async Task<GetBasketResponse> GetBasketsAsync()
        {
            var response = new GetBasketResponse();
            response.BasketItems = await _basketService.GetBasketsAsync();
            return response;
        }

        public async Task<GetBasketByUserNameResponse> GetBasketsByUserNameAsync(GetBasketByUserNameRequest request)
        {
            var response = new GetBasketByUserNameResponse();
            response.Basket = await _basketService.GetBasketsByUserNameAsync(request.UserName);
            return response;
        }
    }
}
