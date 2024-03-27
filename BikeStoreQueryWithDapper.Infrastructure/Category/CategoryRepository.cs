using BikeStoreQueryWithDapper.Domain.CategoryEntity;
using BikeStoreQueryWithDapper.Infrastructure.DATA;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Infrastructure.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperDbContext _dbContext;

        public CategoryRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.CategoryEntity.Category>> GetAll(string a)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<Domain.CategoryEntity.Category>(a);
                return query.ToList();
            }
        }
    }
}
