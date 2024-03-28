

namespace BikeStoreQueryWithDapper.Domain.CommonQuery
{
    public class CommonDTO
    {
        public int order_id { get; set; }

        public int item_id { get; set; }

        public int product_id { get; set; }

        public int product_Id { get; set; }

        public int Brand_Id { get; set; }

        public int category_Id { get; set; }

        public short Model_Year { get; set; }

        public byte order_status { get; set; }

        public DateTime required_date { get; set; }

        public int store_id { get; set; }

        public int staff_id { get; set; }

        public string? phone { get; set; }

        public string? street { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zip_Code { get; set; }

        public int store_Id { get; set; }

        public string? store_name { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public int customer_id { get; set; }

        public string? first_name { get; set; }

        public string? last_name { get; set; }

        public decimal list_price { get; set; }

        public string? product_name { get; set; }

        public int quantity { get; set; }

        public string? customer_name { get; set; }

        public string? email { get; set; }

        public decimal discount { get; set; }

        public DateTime order_date { get; set; }

        public DateTime shipped_date { get; set; }

        public string? daily_avg_sales_amount { get; set; }

        public int total_quantity_sold { get; set; }

    }
}
