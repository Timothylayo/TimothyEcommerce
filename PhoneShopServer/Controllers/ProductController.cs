using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneShopSharedLib.Conracts;
using PhoneShopSharedLib.Models;
using PhoneShopSharedLib.Response;

namespace PhoneShopServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Iproduct _productService;
        public ProductController(Iproduct productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts(bool featured)
        {
            var products = await _productService.GetAllProducts(featured); return Ok(products);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddProduct(Product model)
        {
            if (model is null) return BadRequest("Model is null");
            var response = await _productService.AddProduct(model);
            return Ok(response);
        }

    }
}
