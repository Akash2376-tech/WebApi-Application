using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Common.Models
{
    public class PagedRequest
    {
        private int MaxPageSize = 100;
        public int PageNumber { get; set; } = 1;

        public int PageSize {

            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
        private int _pageSize =10;
    }
}
