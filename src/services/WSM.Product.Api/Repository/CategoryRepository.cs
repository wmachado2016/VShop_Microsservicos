using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using Microsoft.EntityFrameworkCore;
using WSM.Catalog.Api.Context;
using WSM.Catalog.Api.Models;
using WSM.Catalog.Api.ViewModels;

namespace WSM.Catalog.Api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContextCatalog _appDbContextCatalog;

        public CategoryRepository(AppDbContextCatalog appDbContextCatalog)
        {
            _appDbContextCatalog = appDbContextCatalog;
        }

        public async Task<IEnumerable<Category>> GetAll(GetCategory category)
        {
            var cat = await _appDbContextCatalog.Categories.AsNoTracking().AsQueryable().Filter(category).Paginate(category).Sort(category).ToListAsync();
            return cat;
        }

        public async Task<IEnumerable<Category>> GetCategorysProducts()
        {
            return await _appDbContextCatalog.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _appDbContextCatalog.Categories.Where(c => c.CategoryId == id ).FirstOrDefaultAsync();
        }        

        public async Task<Category> Create(Category category)
        {
             _appDbContextCatalog.Categories.Add(category);
            await _appDbContextCatalog.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _appDbContextCatalog.Entry(category).State = EntityState.Modified;
            await _appDbContextCatalog.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Delete(int id)
        {
            var cate = await GetById(id);
            _appDbContextCatalog.Categories.Remove(cate);
            await _appDbContextCatalog.SaveChangesAsync();
            return cate;
        }
    }
}
