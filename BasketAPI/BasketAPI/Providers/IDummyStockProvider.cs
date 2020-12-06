using System;
using System.Threading.Tasks;

namespace BasketAPI.Providers
{
    public interface IDummyStockProvider
    {
        Task<bool> IsInStock(int productId, string Color, int quantity);
    }
}
