using System;
namespace BasketAPI.Exceptions
{

    public class InvalidBasketItemModelException : Exception
    {
        internal InvalidBasketItemModelException(string businessMessage)
            : base(businessMessage)
        {
        }

        internal InvalidBasketItemModelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
