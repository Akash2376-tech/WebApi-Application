using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Common.Models;
using WebApi.Application.Webinars.Queries.Product;

namespace WebApi_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [Authorize(Roles = "Admin")]
        [HttpGet(Name = "GetAllPagedProducts")]
        public async Task<IActionResult> GetPagedProducts([FromQuery] PagedRequest request)
        {
            var response = await _mediator.Send(new GetPagedProductsRequest() { PageNumber = request.PageNumber, PageSize = request.PageSize });

            if (!response.IsSuccess)
                return NotFound(response.Error.Message);

            return Ok(response.Data);
        }
    }
}
