using CostManagement.Buisness;
using CostManagement.Buisness.Service;
using CostManagement.Entity.API.Request;
using CostManagement.Entity.API.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CostAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ILogger<ExpenseController> _logger;
        public readonly CostDBContext context;
        public ExpenseController(ILogger<ExpenseController> logger, CostDBContext _context)
        {
            _logger = logger;
            this.context = _context;
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<ExpenseResponse> GetAll([FromBody] ExpenseRequest request)
        {
            ExpenseResponse response = new ExpenseResponse();
            try
            {
                return await ExpenseService.GetExpenses(context, request);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<ExpenseResponse> Save([FromBody] ExpenseRequest request)
        {
            ExpenseResponse response = new ExpenseResponse();
            try
            {
                return await ExpenseService.SaveExpense(context, request);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }

        [HttpDelete]
        [Route("Delete/ExpenseId/{expenseId}")]
        public async Task<ExpenseResponse> GetAll(Guid expenseId)
        {
            ExpenseResponse response = new ExpenseResponse();
            try
            {
                return await ExpenseService.DeleteExpense(context, expenseId);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}