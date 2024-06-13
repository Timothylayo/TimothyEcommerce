using PhoneShopSharedLib.Models;
using PhoneShopSharedLib.Response;
namespace PhoneShopClient.Services
{
    public interface IProductService
    {
        Action? ProductAction { get; set; }
        Task<ServiceResponse> AddProduct(Product model);
        Task GetAllProducts(bool featuredProducts);
        List<Product> AllProducts { get; set; } 
        List<Product> FeaturedProducts { get; set; } 
    }
}
