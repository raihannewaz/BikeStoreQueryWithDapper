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

        public string Query { get; set; }


        public string cteQuery = @"WITH CTE_StockTableData AS (SELECT c.category_id , c.category_name, b.brand_id, b.brand_name, p.product_id, p.product_name, p.model_year, p.list_price, sto.store_id, sto.quantity, s.store_name, s.phone, s.email, s.street, s.city , s.state, s.zip_code FROM production.categories AS c INNER JOIN production.brands AS b ON c.category_id = b.brand_id INNER JOIN production.products AS p ON c.category_id = p.category_id INNER JOIN production.stocks AS sto ON p.product_id = sto.product_id INNER JOIN sales.stores AS s ON sto.store_id = s.store_id) SELECT store_name, product_name, quantity FROM CTE_StockTableData Where model_year = 2018";




        public string bestOrderAmount = @"SELECT TOP 10 c.customer_id AS customer_id, c.first_name, c.last_name,
                                        MAX(total_purchase_amount) AS list_price FROM (SELECT o.customer_id,
                                        SUM(oi.quantity * oi.list_price) AS total_purchase_amount
                                        FROM sales.orders o JOIN sales.order_items oi ON o.order_id = oi.order_id
                                        GROUP BY o.customer_id) AS customer_purchase JOIN sales.customers c ON customer_purchase.customer_id = c.customer_id 
                                        GROUP BY c.customer_id, c.first_name, c.last_name ORDER BY list_price DESC";

        public string allOrderItems = @"SELECT* From sales.order_items";
    }
}
