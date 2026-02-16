using WebApi.Domain.Entities;

namespace WebApi.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetPagedProducts(int pageNumber , int pageSize);
    }
}
