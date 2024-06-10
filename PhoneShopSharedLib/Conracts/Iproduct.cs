using PhoneShopSharedLib.Models;
using PhoneShopSharedLib.Response;
namespace PhoneShopSharedLib.Conracts
{
    public interface Iproduct
    {
        Task<ServiceResponse> AddProduct(Product model);
        Task<List<Product>> GetAllProducts(bool featuredProducts);
    }
}
