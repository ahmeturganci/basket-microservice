using System;
using System.Collections;
using System.Collections.Generic;
using BasketAPI.Models.ViewModel;

namespace BasketAPI.Test.BasketAPI.Service.DummyData
{
    public class BasketServiceDummyData
    {
        public class AddBasketItem_Success_ReturnTrue : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new AddBasketRequest() { Color = "Yellow", Price = 1.2M, ProductId = 1, ProductName = "Pencil", Quantity = 3, UserName = "Ahmet" } };
                yield return new object[] { new AddBasketRequest() { Color = "Pink", Price = 3.1M, ProductId = 2, ProductName = "Pencil", Quantity = 9, UserName = "Mehmet" } };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public class AddItemToBasket_OutOfStockItem_ReturnFalse : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new AddBasketRequest() { Color = "Cyan", Price = 1.1M, ProductId = 9, ProductName = "Pencil", Quantity = 10, UserName = "Ahmet" } };
                yield return new object[] { new AddBasketRequest() { Color = "Cyan", Price = 1.1M, ProductId = 9, ProductName = "Pencil", Quantity = 100, UserName = "Ahmet" } };
                yield return new object[] { new AddBasketRequest() { Color = "Cyan", Price = 1.1M, ProductId = 9, ProductName = "Pencil", Quantity = 1, UserName = "Ahmet" } };
                yield return new object[] { new AddBasketRequest() { Color = "Cyan", Price = 1.1M, ProductId = 9, ProductName = "Pencil", Quantity = 10, UserName = "Ahmet" } };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public class AddItemToBasket_InvalidBasket_InvalidBasketItemException : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new AddBasketRequest() { Color = "Red", Price = 0, ProductId = 123, ProductName = "Pencil", Quantity = 1, UserName = "Ramiz" } };
                yield return new object[] { new AddBasketRequest() { Color = "Red", Price = 1.1M, ProductId = 0, ProductName = "Pencil", Quantity = 1, UserName = "Ramiz" } };
                yield return new object[] { new AddBasketRequest() { Color = "Red", Price = 1.1M, ProductId = 123, ProductName = null, Quantity = 1, UserName = "Ramiz" } };
                yield return new object[] { new AddBasketRequest() { Color = "Red", Price = 1.1M, ProductId = 123, ProductName = "Pencil", Quantity = 1, UserName = null } };
                yield return new object[] { new AddBasketRequest() { Color = "Red", Price = 1.1M, ProductId = 123, ProductName = "Pencil", Quantity = 0, UserName = "Ramiz" } };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
