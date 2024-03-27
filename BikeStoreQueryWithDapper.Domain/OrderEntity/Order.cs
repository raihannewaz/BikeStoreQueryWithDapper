using BikeStoreQueryWithDapper.Domain.CustomerEntity;
using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Domain.StaffEntity;
using BikeStoreQueryWithDapper.Domain.StoreEntity;
using System;
using System.Collections.Generic;

namespace BikeStoreQueryWithDapper.Domain.OrderEntity;

public partial class Order
{
    public int order_id { get; set; }

    public int customer_id { get; set; }

    public byte order_status { get; set; }

    public DateTime order_date { get; set; }

    public DateTime required_date { get; set; }

    public DateTime shipped_date { get; set; }

    public int store_id { get; set; }

    public int staff_id { get; set; }

    public Customer? Customer { get; set; }

    public Staff? Staff { get; set; }

    public Store? Store { get; set; }
}
