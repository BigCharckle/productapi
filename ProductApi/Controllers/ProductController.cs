using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logic.interfaces;
using Models.products;
using Microsoft.Extensions.Configuration;
namespace ProductApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IRepositoryFromExternal<Product> _productRepository;
        private readonly IConfiguration _config;
        //private readonly ILogger<ProductController> _logger;
        public ProductController(IRepositoryFromExternal<Product> _productRepository, IConfiguration config)
        {
            this._productRepository = _productRepository;
            this._config = config;
        }

        [Route("{id:int}")]
        [HttpGet]
        public Product Details(int id)
        {
            return new Product();
        }

        // GET: ProductController/Create
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Product>> GetFromExternalAsyn()
        {
            var url = _config.GetValue<string>("ExternalUrl");
            return await _productRepository.GetFromExternalAsyn(url);
        }

    }
}
