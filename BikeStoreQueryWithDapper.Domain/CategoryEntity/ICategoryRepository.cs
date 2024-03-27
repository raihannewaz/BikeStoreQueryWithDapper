using BikeStoreQueryWithDapper.Domain.BrandEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Domain.CategoryEntity
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll(string a);
    }
}
