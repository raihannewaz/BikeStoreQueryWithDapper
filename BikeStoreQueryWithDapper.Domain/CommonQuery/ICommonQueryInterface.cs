


using BikeStoreQueryWithDapper.Domain.CategoryEntity;
using BikeStoreQueryWithDapper.Domain.CustomerEntity;
using BikeStoreQueryWithDapper.Domain.ProductEntity;

namespace BikeStoreQueryWithDapper.Domain.CommonQuery
{
    public interface ICommonQueryInterface
    { 
        Task<IEnumerable<CommonDTO>> GetStoreStock(string a);
        Task<IEnumerable<CommonDTO>> GetBestOrderAmount(string a);
        Task<IEnumerable<Customer>> GetCustomerOrdersByIds(int a, string b, string c);
        Task<IEnumerable<CommonDTO>> GetBestSaleProducByDate(string b);
        Task<IEnumerable<CommonDTO>> GetDailyAvgSale(string b);
        Task<IEnumerable<CommonDTO>> GetMostSoldProduct(string b);

        Task<IEnumerable<Customer>> GetCustomerOrdersById(string a);

        Task<IEnumerable<Category>> GetProductWithCat(int id);

    }
}
