using CostManagement.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CostManagement.Entity.API.Request
{
    public class ExpenseRequest : BaseRequest
    {
        public Expense Expense { get; set; }
        public ExpenseRequest()
        {
            Expense = new Expense();
        }
    }
}
