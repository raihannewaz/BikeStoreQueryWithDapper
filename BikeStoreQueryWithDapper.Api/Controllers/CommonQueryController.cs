using BikeStoreQueryWithDapper.Application.CommonCQRS.Queries;
using BikeStoreQueryWithDapper.Domain.CommonQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoreQueryWithDapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonQueryController : ControllerBase
    {
        private readonly ISender _sender;


        public CommonQueryController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("top-10-best-orders-in-amount")]
        public async Task<IActionResult> GetBestOrderInAmount()
        {

            var query = new GetCommonQuery<CommonDTO>
            {
                Query = "bestOrderAmount"
            };

            var data = await _sender.Send(query);


            var swaggerData = data.Select(dto => new
            {
                dto.customer_id,
                dto.first_name,
                dto.last_name,
                dto.list_price
            }).ToList();

            return Ok(swaggerData);
        }

        [HttpGet("store-stock")]
        public async Task<IActionResult> GetStoreStock()
        {
            var query = new GetCommonQuery<CommonDTO>
            {
                Query = "cteQuery"
            };

            var data = await _sender.Send(query);

            var swaggerData = data.Select(dto => new
            {
                dto.store_name,
                dto.product_name,
                dto.quantity
            }).ToList();

            return Ok(swaggerData);
        }


        [HttpGet("customer-orders/{id}/{param}")]
        public async Task<IActionResult> GetCustomerOrders(int id, string param)
        {

            var query = new GetCommonQuery<CommonDTO>
            {
                Query = "customerOrdersByOutParam",
                id = id,
                outParam = param
            };

            var data = await _sender.Send(query);

            var swaggerData = data.Select(dto => new
            {
                dto.customer_name,
                dto.email,
                dto.product_name,
                dto.quantity,
                dto.list_price,
                dto.discount,
                dto.order_date,
                dto.shipped_date
            }).ToList();

            return Ok(swaggerData);
        }


        [HttpGet("best-sale-product-by-date")]
        public async Task<IActionResult> GetStoreStock(DateTime dateStart, DateTime dateEnd)
        {

            var query = new GetCommonQuery<CommonDTO>
            {
                Query = "dateWiseBestSaleProduct",
                startDate = dateStart,
                endDate = dateEnd
            };
            var data = await _sender.Send(query);

            var swaggerData = data.Select(dto => new
            {
                dto.order_date,
                dto.product_name,
                dto.quantity,
                dto.list_price,
                dto.discount,

            }).ToList();

            return Ok(swaggerData);
        }

        [HttpGet("avg-sale-amount-with-date")]
        public async Task<IActionResult> GetAvgSaleAmount()
        {

            var query = new GetCommonQuery<CommonDTO>
            {
                Query = "dailyAvgSellig",
            };

            var data = await _sender.Send(query);

            var swaggerData = data.Select(dto => new
            {
                dto.order_date,
                dto.daily_avg_sales_amount,

            }).ToList();

            return Ok(swaggerData);
        }



        [HttpGet("most-sold-products")]
        public async Task<IActionResult> GetMostSoleProd()
        {

            var query = new GetCommonQuery<CommonDTO>
            {
                Query = "mostSoldProdcut",
            };

            var data = await _sender.Send(query);

            var swaggerData = data.Select(dto => new
            {
                dto.product_name,
                dto.total_quantity_sold

            }).ToList();

            return Ok(swaggerData);
        }
    }
}
