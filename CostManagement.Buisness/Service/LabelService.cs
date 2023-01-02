using CostManagement.Entity.API.Request;
using CostManagement.Entity.API.Response;
using CostManagement.Entity.Common;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CostManagement.Buisness.Service
{
    public static class LabelService
    {
        public async static Task<LabelResponse> GetCategories(CostDBContext _context, LabelRequest request)
        {
            LabelResponse response = new LabelResponse();
            try
            {
                List<Label> Labels = new List<Label>();
                Labels = await _context.Labels.Where(t => t.Name.Contains(request.Label.Name)).ToListAsync();
                if (Labels != null && Labels.Count > 0)
                {
                    response.Labels.AddRange(Labels);
                }
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }


        public async static Task<LabelResponse> SaveLabel(CostDBContext _context, LabelRequest request)
        {
            LabelResponse response = new LabelResponse();
            try
            {

                if (request.Label.Id == Guid.Empty)
                {
                    await _context.Labels.AddAsync(request.Label);
                }
                else
                {
                    Label Label = await _context.Labels.Where(d => d.Id == request.Label.Id).FirstAsync();
                    Label = request.Label;
                }

                await _context.SaveChangesAsync();
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }

        public async static Task<LabelResponse> DeleteLabel(CostDBContext _context, Guid id)
        {
            LabelResponse response = new LabelResponse();
            try
            {

                Label Label = await _context.Labels.FindAsync(id) ?? new Label();
                if (Label != null && Label.Id != Guid.Empty)
                {
                    _context.Labels.Remove(Label);
                }
                await _context.SaveChangesAsync();
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
