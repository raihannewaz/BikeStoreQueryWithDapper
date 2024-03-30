using BikeStoreQueryWithDapper.Domain.OrderEntity;
using BikeStoreQueryWithDapper.Domain.ProductEntity;
using System;
using System.Collections.Generic;

namespace BikeStoreQueryWithDapper.Domain.OrderItemEntity;

public partial class OrderItem
{
    public int order_id { get; set; }

    public int item_id { get; set; }

    public int product_id { get; set; }

    public int quantity { get; set; }

    public decimal list_price { get; set; }

    public decimal discount { get; set; }

    public Order? Order { get; set; }

    public List<Product>? Product { get; set; }
}
