using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using Microsoft.EntityFrameworkCore;
using WSM.Catalog.Api.Context;
using WSM.Catalog.Api.Models;

namespace WSM.Catalog.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContextCatalog _appDbContextCatalog;

        public ProductRepository(AppDbContextCatalog appDbContextCatalog)
        {
            _appDbContextCatalog = appDbContextCatalog;
        }

        public async Task<IEnumerable<Product>> GetAll(Product product)
        {
            return await _appDbContextCatalog.Products.AsQueryable().Apply(product).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _appDbContextCatalog.Products.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> Create(Product product)
        {
            _appDbContextCatalog.Products.Add(product);
            await _appDbContextCatalog.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _appDbContextCatalog.Entry(product).State = EntityState.Modified;
            await _appDbContextCatalog.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(int id)
        {
            var prod = await GetById(id);
            _appDbContextCatalog.Products.Remove(prod);
            await _appDbContextCatalog.SaveChangesAsync();
            return prod;
        }
    }
}
