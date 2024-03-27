using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Domain.CustomerEntity
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll(string a);
    }
}
