﻿using Microsoft.EntityFrameworkCore;
using PhoneShopServer.Data;
using PhoneShopSharedLib.Models;
using PhoneShopSharedLib.Response;
namespace PhoneShopServer.Repositories
{
    public class CategoryRepository(AppDbContext appDbContext) : ICategory
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        public async Task<ServiceResponse> AddCategory(Category model)
        {
            if (model == null) return new ServiceResponse(false, "Model is null");
            var (flag, message) = await CheckName(model.Name!);
            if (flag)
            {
                _appDbContext.Categories.Add(model);
                await Commit();
                return new ServiceResponse(true, "Category Saved");
            }
            return new ServiceResponse(flag, message);
        }

        public async Task<List<Category>> GetAllCategories()=>  await _appDbContext.Categories.ToListAsync();
        

        private async Task Commit() => await _appDbContext.SaveChangesAsync();

        private async Task<ServiceResponse> CheckName(string name)
        {
            var category = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Name!.ToLower()!.Equals(name.ToLower()));
            return category is null ? new ServiceResponse(true, null!) : new ServiceResponse(false, "Category already exist");
        }
    }
}
