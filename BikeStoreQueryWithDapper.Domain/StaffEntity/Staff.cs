﻿using BikeStoreQueryWithDapper.Domain.StoreEntity;
using System;
using System.Collections.Generic;

namespace BikeStoreQueryWithDapper.Domain.StaffEntity;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public byte Active { get; set; }

    public int StoreId { get; set; }

    public int? ManagerId { get; set; }

    public virtual Staff? Manager { get; set; }

    public virtual Store? Store { get; set; }
}
