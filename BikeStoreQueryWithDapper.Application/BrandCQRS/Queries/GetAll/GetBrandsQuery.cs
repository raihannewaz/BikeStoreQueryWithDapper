using BikeStoreQueryWithDapper.Domain.BrandEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Application.BrandCQRS.Queries.GetAll
{
    public class GetBrandsQuery : IRequest<List<Brand>>
    {
        public string sqlQ = "SELECT* From production.Brands";

    }
}
