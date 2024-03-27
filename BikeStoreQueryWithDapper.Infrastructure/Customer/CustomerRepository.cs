using BikeStoreQueryWithDapper.Domain.CustomerEntity;
using BikeStoreQueryWithDapper.Domain.OrderEntity;
using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Infrastructure.DATA;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Infrastructure.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperDbContext _dbContext;

        public CustomerRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.CustomerEntity.Customer>> GetAll(string a)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<Domain.CustomerEntity.Customer>(a);


                return query.ToList();
            }
            }
    }
}
