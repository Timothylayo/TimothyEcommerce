using PhoneShopSharedLib.Models;
using PhoneShopSharedLib.Response;
namespace PhoneShopServer.Repositories
{
    public interface IProduct
    {
        Task<ServiceResponse> AddProduct(Product model);
        Task<List<Product>> GetAllProducts(bool featuredProducts);
    }
}
