using System;
using System.Collections.Generic;
using System.Data;
using WebApi.Application.DTO;
using WebApi.Application.Common;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces;
using WebApi.Application.Common.Models;
using WebApi.Infrastucture.Interfaces;
using Dapper;

namespace WebApi.Infrastucture.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public ProductRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public async Task<IEnumerable<Product>> GetPagedProducts(int pageNumber, int pageSize)
        {
            IEnumerable<Product> products = null;
            try
            {
                using var connection = _dbConnectionFactory.CreateConnection();
                await connection.OpenAsync();
                using var multi = await connection.QueryMultipleAsync(
                "GetProductsPaged",
                new
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                },
                commandType: CommandType.StoredProcedure);
                products = await multi.ReadAsync<Product>();
                connection.Close();
            }
            catch (Exception ex)
            {

            }
            return products;
        }
    }
}
