using PhoneShopSharedLib.Models;
using PhoneShopSharedLib.Response;
namespace PhoneShopServer.Repositories
{
    public interface ICategory
    {
        Task<ServiceResponse> AddCategory(Category model);
        Task<List<Category>> GetAllCategories();
    }
}
