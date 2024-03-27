using System;
using System.Collections.Generic;

namespace BikeStoreQueryWithDapper.Domain.CategoryEntity;

public partial class Category
{
    public int category_id { get; set; }

    public string? category_name { get; set; }

}
