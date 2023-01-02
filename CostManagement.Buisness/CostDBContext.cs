using CostManagement.Entity.Common;
using Microsoft.EntityFrameworkCore;

namespace CostManagement.Buisness
{
    public class CostDBContext : DbContext
    {
        public CostDBContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Categories
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// SubCategories
        /// </summary>
        public DbSet<SubCategory> SubCategories { get; set; }

        /// <summary>
        /// Labels
        /// </summary>
        public DbSet<Label> Labels { get; set; }

        /// <summary>
        /// Expenses
        /// </summary>
        public DbSet<Expense> Expenses { get; set; }
    }
}
