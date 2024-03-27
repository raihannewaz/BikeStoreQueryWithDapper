using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Domain.StockEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Domain.CommonQueryInterface
{
    public interface ICommonQueryInterface<T> where T : class
    {
        Task<List<T>> GetStoreStock(string a);
        Task<List<T>> GetBestOrderAmount(string a);
    }
}
