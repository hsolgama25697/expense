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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        public readonly CostDBContext context;
        public CategoryController(ILogger<CategoryController> logger, CostDBContext _context)
        {
            _logger = logger;
            this.context = _context;
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<CategoryResponse> GetAll([FromBody] CategoryRequest request)
        {
            CategoryResponse response = new CategoryResponse();
            try
            {
                return await CategoryService.GetCategories(context, request);
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
        public async Task<CategoryResponse> Save([FromBody] CategoryRequest request)
        {
            CategoryResponse response = new CategoryResponse();
            try
            {
                return await CategoryService.SaveCategory(context, request);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }

        [HttpDelete]
        [Route("Delete/CategoryId/{categoryId}")]
        public async Task<CategoryResponse> GetAll(Guid categoryId)
        {
            CategoryResponse response = new CategoryResponse();
            try
            {
                return await CategoryService.DeleteCategory(context, categoryId);
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