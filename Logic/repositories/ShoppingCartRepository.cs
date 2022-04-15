using Logic.interfaces;
using Models.transaction;
namespace Logic.repositories
{
    public class ShoppingCartRepository: IShoppingCartRepository
    {
        public decimal CalculateShippingPrice(ShoppingCart shoppingCart)
        {
            return shoppingCart.shippingprice;
        }
        public void CheckOut(ShoppingCart shoppingCart)
        {
            //do nothing for now.
        }

    }
}
