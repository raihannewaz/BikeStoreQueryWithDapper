using BikeStoreQueryWithDapper.Domain.CategoryEntity;
using BikeStoreQueryWithDapper.Domain.CustomerEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Application.CustomerCQRS.Queries.GetAll
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var data = await _customerRepository.GetAll(request.allCustomers);
            return data;
        }
    }
}
