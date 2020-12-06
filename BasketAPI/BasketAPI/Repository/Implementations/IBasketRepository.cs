using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using BasketAPI.Data.Entities;

namespace BasketAPI.Repository.Implementations
{
    public interface IBasketRepository
    {
        Task<IEnumerable<BasketItem>> GetBasketsAsync();
        Task<bool> AddBasketsAsync(BasketItem entity);
        Task<BasketItem> GetBasketsByUserNameAsync(string userName);
          }
    }
