using BikeStoreQueryWithDapper.Domain.CategoryEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Application.CategoryCQRS.Queries.GetAll
{
    public class GetCategoryQuery :  IRequest<List<Category>>
    {
        public string allCategory = @"SELECT* From production.categories";
    }
}
