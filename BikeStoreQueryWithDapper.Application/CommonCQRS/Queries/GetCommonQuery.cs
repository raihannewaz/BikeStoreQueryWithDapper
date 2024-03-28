using BikeStoreQueryWithDapper.Domain.BrandEntity;
using BikeStoreQueryWithDapper.Domain.CustomerEntity;
using BikeStoreQueryWithDapper.Domain.OrderEntity;
using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Domain.StockEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Application.CommonCQRS.Queries
{
    public class GetCommonQuery<T> : IRequest<List<T>> where T : class
    {

        public string? Query { get; set; }


        public string cteQuery = @"WITH CTE_StockTableData AS (SELECT c.category_id , c.category_name, b.brand_id, b.brand_name, p.product_id, p.product_name, 
                                   p.model_year, p.list_price, sto.store_id, sto.quantity, s.store_name, s.phone, s.email, s.street, s.city , s.state, s.zip_code 
                                   FROM production.categories AS c INNER JOIN production.brands AS b ON c.category_id = b.brand_id 
                                   INNER JOIN production.products AS p ON c.category_id = p.category_id INNER JOIN production.stocks AS sto ON p.product_id = sto.product_id 
                                   INNER JOIN sales.stores AS s ON sto.store_id = s.store_id) SELECT store_name, product_name, quantity 
                                   FROM CTE_StockTableData Where model_year = 2018";




        public string bestOrderAmount = @"SELECT TOP 10 c.customer_id AS customer_id, c.first_name, c.last_name,
                                        MAX(total_purchase_amount) AS list_price FROM (SELECT o.customer_id,
                                        SUM(oi.quantity * oi.list_price) AS total_purchase_amount
                                        FROM sales.orders o JOIN sales.order_items oi ON o.order_id = oi.order_id
                                        GROUP BY o.customer_id) AS customer_purchase JOIN sales.customers c ON customer_purchase.customer_id = c.customer_id 
                                        GROUP BY c.customer_id, c.first_name, c.last_name ORDER BY list_price DESC";





        public string outParam;
        public int id;
        public string customerOrdersByOutParam = $"EXEC SP_GetCustomerOrderDetails  ";




        public string mostSoldProdcut = @"SELECT TOP 10 p.product_name, SUM(oi.quantity) AS total_quantity_sold
                                            FROM production.products p
                                            INNER JOIN sales.order_items oi ON p.product_id = oi.product_id
                                            GROUP BY p.product_name
                                            ORDER BY total_quantity_sold DESC";



        public string dailyAvgSellig = @"SELECT order_date, AVG(daily_total_sales_amount) AS daily_avg_sales_amount
                                         FROM (SELECT o.order_date, SUM(oi.quantity * oi.list_price) AS daily_total_sales_amount
                                               FROM sales.orders o  JOIN sales.order_items oi ON o.order_id = oi.order_id
                                               GROUP BY o.order_date, o.order_id) AS daily_sales
                                         GROUP BY order_date
                                         ORDER BY order_date asc";


        public DateTime startDate;
        public DateTime endDate;

        public string GetBestSalePoductByDate(DateTime startDate, DateTime endDate)
        {
            return @$"SELECT o.order_date as order_date, p.product_name as product_name, oi.quantity as quantity, oi.list_price as list_price, oi.discount as discount
                                                  FROM sales.orders o Left JOIN sales.order_items oi ON o.order_id = oi.order_id
	                                              Left JOIN production.products p ON oi.product_id = p.product_id
                                                  WHERE o.order_date BETWEEN '{startDate}' AND '{endDate}' AND oi.quantity =
                                                        (SELECT TOP 1 MAX(total_quantity)
                                                         FROM (SELECT SUM(oi_inner.quantity) AS total_quantity
                                                               FROM sales.order_items oi_inner INNER JOIN sales.orders o_inner ON oi_inner.order_id = o_inner.order_id
                                                               WHERE o_inner.order_date = o.order_date GROUP BY oi_inner.product_id) AS Subquery)
                                                  ORDER BY o.order_date";
        }

    }
}
