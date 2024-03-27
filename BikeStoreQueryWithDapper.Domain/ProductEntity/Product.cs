using BikeStoreQueryWithDapper.Domain.BrandEntity;
using BikeStoreQueryWithDapper.Domain.CategoryEntity;
using System;
using System.Collections.Generic;

namespace BikeStoreQueryWithDapper.Domain.ProductEntity;

public partial class Product
{
    public int Product_Id { get; set; }

    public string? Product_Name { get; set; }

    public int Brand_Id { get; set; }

    public int Category_Id { get; set; }

    public short Model_Year { get; set; }

    public decimal List_Price { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Category { get; set; }

}
