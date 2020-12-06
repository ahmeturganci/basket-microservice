using System;
using Xunit;

namespace BasketAPI.Test
{
    public class BasketAPITests
    {
        [Fact]
        public void Return_Filled_Basket()
        {
            var productActor = CreateTestProbe("products");
            var actorUnderTest = ActorOf(Props.Create<BasketActor>(productActor.Ref));
            actorUnderTest.Tell(
                new BasketActor.GetBasket()
            );

            var result = ExpectMsg<Basket>().Items;
            Assert.Empty(result);
        }

    }
}
