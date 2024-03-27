using BikeStoreQueryWithDapper.Domain.CustomerEntity;
using BikeStoreQueryWithDapper.Domain.OrderEntity;
using BikeStoreQueryWithDapper.Domain.ProductEntity;
using BikeStoreQueryWithDapper.Domain.StaffEntity;
using BikeStoreQueryWithDapper.Domain.StoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Application.CommonCQRS
{
    public class CommonDTO
    {
        //orderitem
        public int order_id { get; set; }

        public int item_id { get; set; }

        public int product_id { get; set; }

        public int quantity { get; set; }

        public decimal list_price { get; set; }

        public decimal discount { get; set; }

        //public Order? Order { get; set; }

       // public Product? Product { get; set; }



        //order

        public int customer_id { get; set; }

        public byte order_status { get; set; }

        public DateTime order_date { get; set; }

        public DateTime required_date { get; set; }

        public DateTime shipped_date { get; set; }

        public int store_id { get; set; }

        public int staff_id { get; set; }

        //public Customer? Customer { get; set; }

        //public Staff? Staff { get; set; }

        //public Store? Store { get; set; }





        //customer

        public string? first_name { get; set; }

        public string? last_name { get; set; }

        public string? phone { get; set; }

        public string? email { get; set; }

        public string? street { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zip_Code { get; set; }


    }
}
