using BikeStoreQueryWithDapper.Domain.BrandEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Application.BrandCQRS.Queries.GetAll
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, List<Brand>>
    {
        private readonly IBrandRepository _brand;

        public GetBrandsQueryHandler(IBrandRepository brand)
        {
            _brand = brand;
        }

        public async Task<List<Brand>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brand.GetAll(request.sqlQ);
            return brands;
        }
    }
}
