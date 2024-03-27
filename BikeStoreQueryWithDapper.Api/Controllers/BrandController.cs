using BikeStoreQueryWithDapper.Application.BrandCQRS.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoreQueryWithDapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ISender _sender;

        public BrandController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _sender.Send(new GetBrandsQuery());
            return Ok(data);
        }
    }
}
