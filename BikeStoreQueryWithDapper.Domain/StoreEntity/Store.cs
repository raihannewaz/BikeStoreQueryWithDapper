using System;
using System.Collections.Generic;

namespace BikeStoreQueryWithDapper.Domain.StoreEntity;

public partial class Store
{
    public int store_Id { get; set; }

    public string? store_name { get; set; }

    public string? phone { get; set; }

    public string? email { get; set; }

    public string? street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? zip_Code { get; set; }
}
