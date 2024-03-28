using BikeStoreQueryWithDapper.Application.CommonCQRS;
using BikeStoreQueryWithDapper.Domain.BrandEntity;
using BikeStoreQueryWithDapper.Domain.CategoryEntity;
using BikeStoreQueryWithDapper.Domain.CommonQuery;
using BikeStoreQueryWithDapper.Domain.CustomerEntity;
using BikeStoreQueryWithDapper.Domain.OrderEntity;
using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Domain.ProductEntity;
using BikeStoreQueryWithDapper.Domain.StockEntity;
using BikeStoreQueryWithDapper.Domain.StoreEntity;
using BikeStoreQueryWithDapper.Infrastructure.DATA;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Infrastructure.CommonQueryRepo
{
    public class CommonQueryRepository : ICommonQueryInterface
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
            }

        }

        public async Task<List<CommonDTO>> GetCustomerOrdersById(int a, string b, string c)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<CommonDTO>(c+" "+a+","+b);

                return query.ToList();
            }
        }

        public async Task<List<CommonDTO>> GetStoreStock(string a)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<CommonDTO>(a);

                return query.ToList();
            }
        }



        public async Task<List<CommonDTO>> GetBestSaleProducByDate(string a)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<CommonDTO>(a);

                return query.ToList();
            }
        }

        public async Task<List<CommonDTO>> GetDailyAvgSale(string b)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<CommonDTO>(b);

                return query.ToList();
            }
        }

        public async Task<List<CommonDTO>> GetMostSoldProduct(string b)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<CommonDTO>(b);

                return query.ToList();
            }
        }


    }
}
