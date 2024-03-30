using BikeStoreQueryWithDapper.Application.CommonCQRS;
using BikeStoreQueryWithDapper.Domain.BrandEntity;
using BikeStoreQueryWithDapper.Domain.CategoryEntity;
using BikeStoreQueryWithDapper.Domain.CommonQuery;
using BikeStoreQueryWithDapper.Domain.CustomerEntity;
using BikeStoreQueryWithDapper.Domain.OrderEntity;
using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Domain.ProductEntity;
using BikeStoreQueryWithDapper.Domain.StockEntity;
using BikeStoreQueryWithDapper.Domain.StoreEntity;
using BikeStoreQueryWithDapper.Infrastructure.DATA;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Infrastructure.CommonQueryRepo
{
    public class CommonQueryRepository : ICommonQueryInterface
    {
        private readonly DapperDbContext _dbContext;

        public CommonQueryRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CommonDTO>> GetBestOrderAmount(string a)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<CommonDTO>(a);

                return query.ToList();
            }

        }

        public async Task<IEnumerable<Domain.CustomerEntity.Customer>> GetCustomerOrdersByIds(int a, string b, string c)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var dictionary = new Dictionary<int, Domain.CustomerEntity.Customer>();


                var query = await conn.QueryAsync<Domain.CustomerEntity.Customer, Order, Domain.CustomerEntity.Customer>(c+" "+a+","+b,
                    (cust, orders)=>
                    {
                        if (!dictionary.TryGetValue(cust.customer_id, out var customers))
                        {
                            customers = cust;
                            customers.Order = new List<Order>();
                            dictionary.Add(customers.customer_id, customers);
                        }
                        customers?.Order?.Add(orders);
                        return customers;
                    },
                    splitOn: "customer_id"
                    );

                return dictionary.Values;
            }
        }

        public async Task<IEnumerable<CommonDTO>> GetStoreStock(string a)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<CommonDTO>(a);

                return query.ToList();
            }
        }



        public async Task<IEnumerable<CommonDTO>> GetBestSaleProducByDate(string a)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<CommonDTO>(a);

                return query.ToList();
            }
        }

        public async Task<IEnumerable<CommonDTO>> GetDailyAvgSale(string b)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<CommonDTO>(b);

                return query.ToList();
            }
        }

        public async Task<IEnumerable<CommonDTO>> GetMostSoldProduct(string b)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var query = await conn.QueryAsync<CommonDTO>(b);

                return query.ToList();
            }
        }


        //public async Task<IEnumerable<Domain.CustomerEntity.Customer>> GetCustomerOrdersById(string a)
        //{
        //    using (var conn = _dbContext.CreateConnection())
        //    {
        //        var dictionaryCust = new Dictionary<int, Domain.CustomerEntity.Customer>();

        //        var query = await conn.QueryAsync<Domain.CustomerEntity.Customer, Order, OrderItem, Domain.CustomerEntity.Customer>(a,
        //            (cust, order, orderItem) =>
        //            {
        //                if (!dictionaryCust.TryGetValue(cust.customer_id, out var customer))
        //                {
        //                    customer = cust;
        //                    customer.Order = new List<Order>();
        //                    dictionaryCust.Add(customer.customer_id, customer);
        //                }

        //                if (!customer.Order.Any(o => o.order_id == order.order_id))
        //                {
        //                    customer.Order.Add(order);
        //                    order.OrderItem = new List<OrderItem>();
        //                }

        //                var existingOrder = customer.Order.FirstOrDefault(o => o.order_id == order.order_id);
        //                existingOrder?.OrderItem?.Add(orderItem);


        //                return customer;
        //            },
        //            splitOn: "order_id, item_id"
        //        );

        //        return dictionaryCust.Values;
        //    }
        //}


        public async Task<IEnumerable<Domain.CategoryEntity.Category>> GetProductWithCat(int id)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                //string a = $@"SELECT c.*, p.* From production.categories c INNER JOIN production.products p ON p.category_id = c.category_id where c.category_id = {id}";
                string a = $@"SELECT * From production.categories where category_id = {id} Select * from production.products";

                var results = await conn.QueryMultipleAsync(a);


                var category = await results.ReadSingleAsync<Domain.CategoryEntity.Category>();
                var product = await results.ReadAsync<Product>();
                category.Product = product.ToList();


                return new List<Domain.CategoryEntity.Category> { category };
            }
        }

        public async Task<IEnumerable<Domain.CustomerEntity.Customer>> GetCustomerOrdersById(string a)
        {
            using (var conn = _dbContext.CreateConnection())
            {
                var results = await conn.QueryMultipleAsync(a);


                var customer = await results.ReadSingleAsync<Domain.CustomerEntity.Customer>();
                var orders = await results.ReadAsync<Order>();
                var orderItems = await results.ReadAsync<OrderItem>();
                var prod = await results.ReadAsync<Product>();

                customer.Order = orders.ToList();
                foreach (var order in customer.Order)
                {
                    order.OrderItem = orderItems.Where(oi => oi.order_id == order.order_id).ToList();

                    foreach (var orderItem in order.OrderItem)
                    {
                        orderItem.Product = prod.Where(p=>p.product_id ==  orderItem.product_id).ToList();
                    }
                }

                return new List<Domain.CustomerEntity.Customer> { customer };
            }
        }

    }
}
