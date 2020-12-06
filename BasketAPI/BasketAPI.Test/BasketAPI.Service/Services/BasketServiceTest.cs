using BasketAPI.Providers;
using BasketAPI.Repository.Implementations;
using Moq;
using System.Threading.Tasks;
using Xunit;
using static BasketAPI.Test.BasketAPI.Service.DummyData.BasketServiceDummyData;
using BasketAPI.Models.ViewModel;
using BasketAPI.Data.Entities;
using BasketAPI.Services;
using BasketAPI.Exceptions;

namespace BasketAPI.Test.BasketAPI.Service.Services
{
    public class BasketServiceTest
    {
        private readonly Mock<IBasketRepository> _mockBasketRepository;
        private readonly Mock<IDummyStockProvider> _mockDummyStockProvider;

        public BasketServiceTest()
        {
            _mockBasketRepository = new Mock<IBasketRepository>();
            _mockDummyStockProvider = new Mock<IDummyStockProvider>();
        }

        [Theory]
        [ClassData(typeof(AddBasketItem_Success_ReturnTrue))]
        public async Task AddBasketItem_Success_ReturnTrue(AddBasketRequest basketRequest)
        {
            //arrange
            _mockBasketRepository.Setup(x => x.AddBasketsAsync(It.IsAny<BasketItem>())).ReturnsAsync(true);
            _mockDummyStockProvider.Setup(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(true);
            var basketService = new BasketService(_mockBasketRepository.Object, _mockDummyStockProvider.Object);

            //act
            var result = await basketService.AddBasketsAsync(basketRequest);

            //assert
            Assert.True(result.IsSuccess);
            _mockBasketRepository.Verify(x => x.AddBasketsAsync(It.IsAny<BasketItem>()), Times.Once);
            _mockDummyStockProvider.Verify(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Once);
        }

        [Theory]
        [ClassData(typeof(AddItemToBasket_OutOfStockItem_ReturnFalse))]
        public async Task AddItemToBasket_OutOfStockItem_ReturnFalse(AddBasketRequest basketRequest)
        {
            //arrange
            _mockDummyStockProvider.Setup(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns((int productId, string color, int quantity) =>
                {
                    if (productId == 9 && color == "Cyan" && quantity < 10)
                    {
                        return Task.FromResult(true);
                    }

                    return Task.FromResult(false);
                }
            );

            var basketService = new BasketService(_mockBasketRepository.Object, _mockDummyStockProvider.Object);

            //act
            var result = await basketService.AddBasketsAsync(basketRequest);

            //assert
            Assert.False(result.IsSuccess);
            _mockBasketRepository.Verify(x => x.AddBasketsAsync(It.IsAny<BasketItem>()), Times.Once);
            _mockDummyStockProvider.Verify(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Once);
        }

        [Theory]
        [ClassData(typeof(AddItemToBasket_InvalidBasket_InvalidBasketItemException))]
        public async Task AddItemToBasket_InvalidBasket_InvalidBasketItemException(AddBasketRequest basketRequest)
        {
            //arrange
            _mockDummyStockProvider.Setup(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(true);
            var basketService = new BasketService(_mockBasketRepository.Object, _mockDummyStockProvider.Object);

            //act & assert
            await Assert.ThrowsAsync<InvalidBasketItemModelException>(() => basketService.AddBasketsAsync(basketRequest));
            _mockDummyStockProvider.Verify(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Never);
            _mockBasketRepository.Verify(x => x.AddBasketsAsync(It.IsAny<BasketItem>()), Times.Never);
        }


    }
}
