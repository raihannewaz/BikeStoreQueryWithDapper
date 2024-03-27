using BikeStoreQueryWithDapper.Domain.CustomerEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Application.CustomerCQRS.Queries.GetAll
{
    public class GetCustomersQuery: IRequest<List<Customer>>
    {
        public string allCustomers = "SELECT* From sales.customers";
    }
}
