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
    public class LabelController : ControllerBase
    {
        private readonly ILogger<LabelController> _logger;
        public readonly CostDBContext context;
        public LabelController(ILogger<LabelController> logger, CostDBContext _context)
        {
            _logger = logger;
            this.context = _context;
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<LabelResponse> GetAll([FromBody] LabelRequest request)
        {
            LabelResponse response = new LabelResponse();
            try
            {
                return await LabelService.GetCategories(context, request);
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
        public async Task<LabelResponse> Save([FromBody] LabelRequest request)
        {
            LabelResponse response = new LabelResponse();
            try
            {
                return await LabelService.SaveLabel(context, request);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }

        [HttpDelete]
        [Route("Delete/LabelId/{LabelId}")]
        public async Task<LabelResponse> GetAll(Guid LabelId)
        {
            LabelResponse response = new LabelResponse();
            try
            {
                return await LabelService.DeleteLabel(context, LabelId);
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