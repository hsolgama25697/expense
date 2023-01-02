using CostManagement.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CostManagement.Entity.API.Response
{
    public class SubCategoryResponse
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// StatusCode
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public SubCategoryResponse()
        {
            SubCategories = new List<SubCategory>();
        }
    }
}
