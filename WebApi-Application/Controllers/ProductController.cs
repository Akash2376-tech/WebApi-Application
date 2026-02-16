using MediatR;
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
        [HttpGet("GetAllPagedProducts")]
        public async Task<PagedResponse<GetPagedProductsResponse>> GetPagedProducts([FromQuery] PagedRequest request)
        {
            var response = await _mediator.Send(new GetPagedProductsRequest() { PageNumber = request.PageNumber, PageSize = request.PageSize });
            return response;
        }
    }
}
