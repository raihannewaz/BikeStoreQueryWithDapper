using BikeStoreQueryWithDapper.Domain.CategoryEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Application.CategoryCQRS.Queries.GetAll
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<Category>>
    {
        private readonly ICategoryRepository _cateRepo;

        public GetCategoryQueryHandler(ICategoryRepository cateRepo)
        {
            _cateRepo = cateRepo;
        }

        public async Task<List<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var req = await _cateRepo.GetAll(request.allCategory);
            return req;
        }
    }
}
