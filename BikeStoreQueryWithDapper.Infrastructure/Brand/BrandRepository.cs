using BikeStoreQueryWithDapper.Domain.BrandEntity;
using BikeStoreQueryWithDapper.Infrastructure.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BikeStoreQueryWithDapper.Infrastructure.Brand
{
    public class BrandRepository : IBrandRepository
    {
        private readonly DapperDbContext _dbContext;

        public BrandRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.BrandEntity.Brand>> GetAll(string a)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var brands = await conn.QueryAsync<Domain.BrandEntity.Brand>(a);
                return brands.ToList();
            }
        }
    }
}
