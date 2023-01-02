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
    public class SubCategoryController : ControllerBase
    {
        private readonly ILogger<SubCategoryController> _logger;
        public readonly CostDBContext context;
        public SubCategoryController(ILogger<SubCategoryController> logger, CostDBContext _context)
        {
            _logger = logger;
            this.context = _context;
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<SubCategoryResponse> GetAll([FromBody] SubCategoryRequest request)
        {
            SubCategoryResponse response = new SubCategoryResponse();
            try
            {
                return await SubCategoryService.GetSubCategories(context, request);
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
        public async Task<SubCategoryResponse> Save([FromBody] SubCategoryRequest request)
        {
            SubCategoryResponse response = new SubCategoryResponse();
            try
            {
                return await SubCategoryService.SaveSubCategory(context, request);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }

        [HttpDelete]
        [Route("Delete/SubCategoryId/{subCategoryId}")]
        public async Task<SubCategoryResponse> GetAll(Guid subCategoryId)
        {
            SubCategoryResponse response = new SubCategoryResponse();
            try
            {
                return await SubCategoryService.DeleteSubCategory(context, subCategoryId);
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