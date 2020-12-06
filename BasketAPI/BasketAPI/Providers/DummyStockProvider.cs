using System;
using System.Threading.Tasks;

namespace BasketAPI.Providers
{
    public class DummyStockProvider : IDummyStockProvider
    {
        public Task<bool> IsInStock(int productId, string color, int quantity)
        {
            return Task.FromResult(true);
        }
    }
}
