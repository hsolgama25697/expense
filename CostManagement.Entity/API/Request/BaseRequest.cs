using CostManagement.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CostManagement.Entity.API.Request
{
    public class BaseRequest
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public string SortBy { get; set; } = "";
          
    }
}
