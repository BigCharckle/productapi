using NUnit.Framework;
using System.Collections.Generic;
using Logic.interfaces;
using ProductApi.Controllers;
using Logic.repositories;
using Models.culture;
using Models.enums;
using Models.transaction;
using Moq;

namespace Api.Test
{
    class ShoppingCartControllerTest
    {
        private static ShoppingCartController _mokCountroller; 
        private static ShoppingCartController _countroller;
        Mock<IShoppingCartRepository> mockRepository = new Mock<IShoppingCartRepository>();

        private ShoppingCart _shoppingCartHighShippingPrice;  //above $50 to return $20 for shipping

        private ShoppingCart _shoppingCartLowShippingPrice; //bellow or equals $50, to return $10 for shipping

        private Country mokCountryAu = new Country { id = 1, name = "Australia", currency = Currencies.AUD, rate = (decimal)1.000 };
        //private Country mokCountryUS = new Country { id = 1, name = "United States", currency = Currencies.USD, rate = (decimal)0.749 };

        [SetUp]
        public void Setup()
        {

            _shoppingCartHighShippingPrice = new ShoppingCart(mokItemsAboveAUD50(), mokCountryAu);
            _shoppingCartLowShippingPrice = new ShoppingCart(mokItemsBellowAUD50(), mokCountryAu);

            mockRepository.Setup(m => m.CalculateShippingPrice(_shoppingCartHighShippingPrice)).Returns(20);
            mockRepository.Setup(m => m.CalculateShippingPrice(_shoppingCartLowShippingPrice)).Returns(10);

            mockRepository.Setup(m => m.CheckOut(_shoppingCartHighShippingPrice)).Verifiable();
            //mockRepository.Setup(m => m.CheckOut(ShoppingCartHighShippingPrice)).Callback<ShoppingCart>(k => { k.id = 99; });
            _mokCountroller = new ShoppingCartController(mockRepository.Object);
            _countroller = new ShoppingCartController(new ShoppingCartRepository());
        }

        [Test]
        /// Shipping = $20
        public void CalculateHighShippingPriceMokTest() 
        {
            var result = _mokCountroller.CalculateShippingPrice(new ShoppingCart(mokItemsAboveAUD50(), mokCountryAu));
            Assert.AreEqual(result, 20);
        }

        /// <summary>
        /// shipping = $10
        /// </summary>
        [Test]
        public void CalculateLowShippingPriceMokTest()
        {
            var result = _mokCountroller.CalculateShippingPrice(new ShoppingCart(mokItemsBellowAUD50(), mokCountryAu));
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void CheckoutMokTest()
        {
            var result = false;
            try
            {
                _mokCountroller.CheckOut(new ShoppingCart(mokItemsBellowAUD50(), mokCountryAu));
                result = true;
            }
            catch
            {
                result = false;
            }
            Assert.AreEqual(result, true);
        }

        [Test]
        public void CalculateLowShippingPriceUnitTest()
        {
            var result = _countroller.CalculateShippingPrice(_shoppingCartLowShippingPrice);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void CalculateHighShippingPriceUnitTest()
        {
            var result = _countroller.CalculateShippingPrice(_shoppingCartHighShippingPrice);
            Assert.AreEqual(result, 20);
        }
        public void CheckoutUnitTest()
        {
            var result = _mokCountroller.CheckOut(new ShoppingCart(mokItemsAboveAUD50(), mokCountryAu));
            Assert.AreEqual(result, true);
        }


        private static List<CartItem> mokItemsBellowAUD50()
        {
            var lst = new List<CartItem>();
            lst.Add(new CartItem { id = 1, price = (decimal)10.25, quantity = 2 });
            lst.Add(new CartItem { id = 3, price = (decimal)11.55, quantity = 1 });
            lst.Add(new CartItem { id = 5, price = (decimal)3.99, quantity = 3 });
            return lst;
        }
        private List<CartItem> mokItemsAboveAUD50()
        {
            var lst = new List<CartItem>();
            lst.Add(new CartItem { id = 2, price = (decimal)20.25, quantity = 2 });
            lst.Add(new CartItem { id = 3, price = (decimal)31.55, quantity = 1 });
            lst.Add(new CartItem { id = 7, price = (decimal)3.99, quantity = 5 });
            return lst;
        }
    }
}
