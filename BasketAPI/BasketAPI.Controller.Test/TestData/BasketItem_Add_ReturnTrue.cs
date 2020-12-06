using System.Collections;
using System.Collections.Generic;
namespace BasketAPI.Controller.Test.TestData
{
    public class BasketItem_Add_ReturnTrue : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new AddBasketRequest() { Color = "Red", Price = 1.1M, ProductId = 123, ProductName = "T-Shirt", Quantity = 1, UserName = "Erdi" } };
            yield return new object[] { new AddBasketRequest() { Color = "Red", Price = 1.1M, ProductId = 123, ProductName = "T-Shirt", Quantity = 9, UserName = "Erdi" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
