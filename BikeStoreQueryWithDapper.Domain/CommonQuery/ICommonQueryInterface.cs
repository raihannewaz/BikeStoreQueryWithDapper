


namespace BikeStoreQueryWithDapper.Domain.CommonQuery
{
    public interface ICommonQueryInterface
    { 
        Task<List<CommonDTO>> GetStoreStock(string a);
        Task<List<CommonDTO>> GetBestOrderAmount(string a);
        Task<List<CommonDTO>> GetCustomerOrdersById(int a, string b, string c);
        Task<List<CommonDTO>> GetBestSaleProducByDate(string b);
        Task<List<CommonDTO>> GetDailyAvgSale(string b);
        Task<List<CommonDTO>> GetMostSoldProduct(string b);

    }
}
