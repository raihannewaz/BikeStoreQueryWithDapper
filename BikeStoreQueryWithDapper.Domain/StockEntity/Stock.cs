using BikeStoreQueryWithDapper.Domain.ProductEntity;
using BikeStoreQueryWithDapper.Domain.StoreEntity;
using System;
using System.Collections.Generic;

namespace BikeStoreQueryWithDapper.Domain.StockEntity;

public partial class Stock
{
    public int store_id { get; set; }

    public int Product_Id { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Store? Store { get; set; }
}
