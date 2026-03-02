using MediatR;
using AutoMapper;
using WebApi.Application.Common.Models;
using WebApi.Domain.Interfaces;
using System.Collections.Generic;

namespace WebApi.Application.Webinars.Queries.Product
{
    public class GetPagedProductsQueryHandler : IRequestHandler<GetPagedProductsRequest, Result<PagedResponse<GetPagedProductsResponse>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetPagedProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }
        public async Task<Result<PagedResponse<GetPagedProductsResponse>>> Handle(GetPagedProductsRequest request, CancellationToken cancellationToken)
        {
            var response = await _productRepository.GetPagedProducts(request.PageNumber, request.PageSize);
            var pagedResponseData = _mapper.Map<IEnumerable<GetPagedProductsResponse>>(response);
            
            if (pagedResponseData.Any())
            {
                var mappedResponse =  new PagedResponse<GetPagedProductsResponse>()
                {
                    Data = pagedResponseData,
                    TotalRecords = pagedResponseData.Count(),
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize
                };

                return Result<PagedResponse<GetPagedProductsResponse>>
                .Success(mappedResponse);
            }

            var error = new Error("","No Data Found !");

            return Result<PagedResponse<GetPagedProductsResponse>>
                .Failure(error);

        }
    }
}
