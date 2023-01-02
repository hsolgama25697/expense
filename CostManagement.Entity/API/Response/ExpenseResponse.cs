using CostManagement.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CostManagement.Entity.API.Response
{
    public class ExpenseResponse
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// StatusCode
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        public List<Expense> Expenses { get; set; }
        public ExpenseResponse()
        {
            Expenses = new List<Expense>();
        }
    }
}
