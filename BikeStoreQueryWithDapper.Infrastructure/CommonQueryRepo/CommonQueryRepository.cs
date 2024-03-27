using BikeStoreQueryWithDapper.Application.CommonCQRS;
using BikeStoreQueryWithDapper.Domain.BrandEntity;
using BikeStoreQueryWithDapper.Domain.CategoryEntity;
using BikeStoreQueryWithDapper.Domain.CommonQueryInterface;
using BikeStoreQueryWithDapper.Domain.CustomerEntity;
using BikeStoreQueryWithDapper.Domain.OrderEntity;
using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Domain.ProductEntity;
using BikeStoreQueryWithDapper.Domain.StockEntity;
using BikeStoreQueryWithDapper.Domain.StoreEntity;
using BikeStoreQueryWithDapper.Infrastructure.DATA;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Infrastructure.CommonQueryRepo
{
    public class CommonQueryRepository<T> : ICommonQueryInterface<CommonDTO>, ICommonQueryInterface<Stock>
    {
        private readonly DapperDbContext _dbContext;

        public CommonQueryRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CommonDTO>> GetBestOrderAmount(string a)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<CommonDTO>(a);


                return query.ToList();

                //var query = await conn.QueryMultipleAsync(a);
                //IEnumerable<OrderItem> enumerable = await query.ReadAsync<OrderItem>();
                //return enumerable.ToList();

            }
        }

        public async Task<List<Stock>> GetStoreStock(string a)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<Stock,Product, Domain.BrandEntity.Brand, Domain.CategoryEntity.Category,Store, Stock>(
                    a,
                    (stock, product,brand,category,store) =>
                    {
                        stock.Product = product;
                        stock.Store = store;
                        product.Brand = brand;
                        product.Category = category;
                        return stock;
                    }, splitOn: "order_id, customer_id"
                    );

                return query.ToList();
            }
        }

        Task<List<Stock>> ICommonQueryInterface<Stock>.GetBestOrderAmount(string a)
        {
            throw new NotImplementedException();
        }

        Task<List<CommonDTO>> ICommonQueryInterface<CommonDTO>.GetStoreStock(string a)
        {
            throw new NotImplementedException();
        }
    }
}
