using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Common.Models;

namespace WebApi.Application.Webinars.Queries.Product
{
    public class GetPagedProductsRequest : PagedRequest, IRequest<Result<PagedResponse<GetPagedProductsResponse>>>
    {
    }
}
