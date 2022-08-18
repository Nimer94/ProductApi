using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Modlel;

namespace ProductApi.Repository
{
    public class ProductManagerRepository : IProductManagerRepository
    {
        private readonly ProductContext _db;

        public ProductManagerRepository(ProductContext db)
        {
            _db = db;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            await _db.Products.AddRangeAsync(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> IsExist(string SerialNumber)
        {
            bool isexist = false;
            var product = await _db.Products.FirstOrDefaultAsync(p => p.SerialNumber == SerialNumber);
            if(product != null)
            {
                isexist = true;
            }
            return isexist;
        }
    }
}
