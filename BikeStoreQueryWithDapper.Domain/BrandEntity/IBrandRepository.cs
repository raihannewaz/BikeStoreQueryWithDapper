using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Domain.BrandEntity
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAll(string a);
    }
}
