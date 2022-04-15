using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic.interfaces;
using Models.transaction;
using Microsoft.Extensions.Configuration;

namespace ProductApi.Controllers
{
        [ApiController]
        [Route("[controller]")]    
    public class ShoppingCartController : Controller
    {
        private IShoppingCartRepository _shoppingCartRepository;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public ShoppingCartController(IShoppingCartRepository shoppingCatRepository)
        {
            this._shoppingCartRepository = shoppingCatRepository;
        }
        [Route("shippingprice")]
        [HttpPost]
        public decimal CalculateShippingPrice(ShoppingCart cart)
        {
            return cart.shippingprice * cart.country.rate;
        }
        [Route("checkout")]
        [HttpPost]
        public IActionResult CheckOut(ShoppingCart cart)
        {
            return Ok(cart);
        }

    }
}
