using Models.transaction;

namespace Logic.interfaces
{
    public interface IShoppingCartRepository
    {
        decimal CalculateShippingPrice(ShoppingCart shoppingCart);
        void CheckOut(ShoppingCart shoppingCart);

    }
}
