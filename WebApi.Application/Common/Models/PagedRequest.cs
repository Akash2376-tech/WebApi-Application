using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.Common.Models
{
    public class PagedRequest
    {
        // Changed Model As Validation Are Handled By Fluent Validation
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
