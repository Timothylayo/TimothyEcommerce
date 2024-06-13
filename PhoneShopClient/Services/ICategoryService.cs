using PhoneShopSharedLib.Models;
using PhoneShopSharedLib.Response;

namespace PhoneShopClient.Services
{
    public interface ICategoryService 
    {
        Action? CategoryAction { get; set; }
        Task<ServiceResponse> AddCategory(Category model);
        Task GetAllCategories();

        List<Category> AllCategories { get; set; }
    }
}
