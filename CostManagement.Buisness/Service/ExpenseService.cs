using CostManagement.Entity.API.Request;
using CostManagement.Entity.API.Response;
using CostManagement.Entity.Common;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CostManagement.Buisness.Service
{
    public static class ExpenseService
    {
        public async static Task<ExpenseResponse> GetExpenses(CostDBContext _context, ExpenseRequest request)
        {
            ExpenseResponse response = new ExpenseResponse();
            try
            {
                List<Expense> expenses = new List<Expense>();
                if (request.Page > 0 && request.PageSize > 0)
                {
                    var skip = (request.Page - 1) * request.PageSize;
                    expenses = await _context.Expenses.Skip(skip).Take(request.PageSize).ToListAsync();
                }
                else
                {
                    expenses = await _context.Expenses.ToListAsync();
                }

                if (expenses != null && expenses.Count > 0)
                {
                    foreach (var item in expenses)
                    {
                        Category category = await _context.Categories.Where(t => t.Id == item.CategoryId).FirstAsync();
                        if (category != null && category.Id != Guid.Empty)
                        {
                            item.Category = category;
                        }

                        SubCategory subCategory = await _context.SubCategories.Where(t => t.Id == item.CategoryId).FirstAsync();
                        if (subCategory != null && subCategory.Id != Guid.Empty)
                        {
                            item.Category.SubCategories.Add(subCategory);
                        }
                        response.Expenses.Add(item);

                        List<Label> labels = new List<Label>();
                        foreach (var labelId in item.LabelId.Split(","))
                        {
                            Label label = await _context.Labels.Where(t => t.Id == Guid.Parse(labelId)).FirstAsync();
                            if (label != null && label.Id != Guid.Empty)
                            {
                                item.Labels.Add(label);
                            }
                        }
                        response.Expenses.Add(item);

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


        public async static Task<ExpenseResponse> SaveExpense(CostDBContext _context, ExpenseRequest request)
        {
            ExpenseResponse response = new ExpenseResponse();
            try
            {

                if (request.Expense.Id == Guid.Empty)
                {
                    await _context.Expenses.AddAsync(request.Expense);
                }
                else
                {
                    Expense expense = await _context.Expenses.Where(d => d.Id == request.Expense.Id).FirstAsync();
                    expense = request.Expense;
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

        public async static Task<ExpenseResponse> DeleteExpense(CostDBContext _context, Guid id)
        {
            ExpenseResponse response = new ExpenseResponse();
            try
            {

                Expense expense = await _context.Expenses.FindAsync(id) ?? new Expense();
                if (expense != null)
                {
                    _context.Expenses.Remove(expense);
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
