using CostManagement.Entity.API.Request;
using CostManagement.Entity.API.Response;
using CostManagement.Entity.Common;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CostManagement.Buisness.Service
{
    public static class SubCategoryService
    {
        public async static Task<SubCategoryResponse> GetSubCategories(CostDBContext _context, SubCategoryRequest request)
        {
            SubCategoryResponse response = new SubCategoryResponse();
            try
            {
                List<SubCategory> subCategories = new List<SubCategory>();
                if (request.Page > 0 && request.PageSize > 0)
                {
                    var skip = (request.Page - 1) * request.PageSize;
                    subCategories = await _context.SubCategories.Where(t => t.Name.Contains(request.SubCategory.Name)).Skip(skip).Take(request.PageSize).ToListAsync();
                }
                else
                {
                    subCategories = await _context.SubCategories.Where(t => t.Name.Contains(request.SubCategory.Name)).ToListAsync();
                }

                if (subCategories != null && subCategories.Count > 0)
                {
                    response.SubCategories.AddRange(subCategories);
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


        public async static Task<SubCategoryResponse> SaveSubCategory(CostDBContext _context, SubCategoryRequest request)
        {
            SubCategoryResponse response = new SubCategoryResponse();
            try
            {

                if (request.SubCategory.Id == Guid.Empty)
                {
                    await _context.SubCategories.AddAsync(request.SubCategory);
                }
                else
                {
                    SubCategory subCategory = await _context.SubCategories.Where(d => d.Id == request.SubCategory.Id).FirstAsync();
                    subCategory = request.SubCategory;
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

        public async static Task<SubCategoryResponse> DeleteSubCategory(CostDBContext _context, Guid id)
        {
            SubCategoryResponse response = new SubCategoryResponse();
            try
            {

                SubCategory subCategory = await _context.SubCategories.FindAsync(id) ?? new SubCategory();
                if (subCategory != null && subCategory.Id != Guid.Empty)
                {
                    _context.SubCategories.Remove(subCategory);
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
