using BikeStoreQueryWithDapper.Application.CommonCQRS;
using BikeStoreQueryWithDapper.Application.CommonCQRS.Queries;
using BikeStoreQueryWithDapper.Domain.OrderItemEntity;
using BikeStoreQueryWithDapper.Domain.StockEntity;
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
            return Ok(data);
        }

        [HttpGet("store-stock")]
        public async Task<IActionResult> GetStoreStock()
        {
            var query = new GetCommonQuery<Stock>
            {
                Query = "cteQuery"
            };

            var data = await _sender.Send(query);
            return Ok(data);
        }
    }
}
