using CostManagement.Entity.API.Request;
using CostManagement.Entity.API.Response;
using CostManagement.Entity.Common;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CostManagement.Buisness.Service
{
    public static class CategoryService
    {
        public async static Task<CategoryResponse> GetCategories(CostDBContext _context, CategoryRequest request)
        {
            CategoryResponse response = new CategoryResponse();
            try
            {
                List<Category> categories = new List<Category>();
                if (request.Page > 0 && request.PageSize > 0)
                {
                    var skip = (request.Page - 1) * request.PageSize;
                    categories = await _context.Categories.Where(t => t.Name.Contains(request.Category.Name)).Skip(skip).Take(request.PageSize).ToListAsync();
                }
                else
                {
                    categories = await _context.Categories.Where(t => t.Name.Contains(request.Category.Name)).ToListAsync();
                }

                if (categories != null && categories.Count > 0)
                {
                    foreach (var item in categories)
                    {
                        List<SubCategory> subCategories = await _context.SubCategories.Where(t => t.CategoryId == item.Id).ToListAsync();
                        if (subCategories != null && subCategories.Count > 0)
                        {
                            item.SubCategories.AddRange(subCategories);
                        }
                        response.Categories.Add(item);
                    }
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


        public async static Task<CategoryResponse> SaveCategory(CostDBContext _context, CategoryRequest request)
        {
            CategoryResponse response = new CategoryResponse();
            try
            {

                if (request.Category.Id == Guid.Empty)
                {
                    await _context.Categories.AddAsync(request.Category);
                }
                else
                {
                    Category category = await _context.Categories.Where(d => d.Id == request.Category.Id).FirstAsync();
                    category = request.Category;
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

        public async static Task<CategoryResponse> DeleteCategory(CostDBContext _context, Guid id)
        {
            CategoryResponse response = new CategoryResponse();
            try
            {

                Category category = await _context.Categories.FindAsync(id) ?? new Category();
                if (category != null)
                {
                    _context.Categories.Remove(category);
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
