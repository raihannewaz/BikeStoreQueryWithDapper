using System;
using System.Collections.Generic;

namespace BikeStoreQueryWithDapper.Domain.CustomerEntity;

public partial class Customer
{
    public int customer_id { get; set; }

    public string? first_name { get; set; }

    public string? last_name { get; set; }

    public string? phone { get; set; }

    public string? email { get; set; }

    public string? street { get; set; }

    public string? city { get; set; }

    public string? state { get; set; }

    public string? zip_Code { get; set; }

}
