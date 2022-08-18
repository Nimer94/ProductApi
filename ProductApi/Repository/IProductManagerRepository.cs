using ProductApi.Modlel;

namespace ProductApi.Repository
{
    public interface IProductManagerRepository
    {
        Task<Product> CreateProduct(Product product);
        Task<bool> IsExist(string SerialNumber);


    }
}
