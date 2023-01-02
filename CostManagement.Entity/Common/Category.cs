using CostManagement.Entity.Shared;

namespace CostManagement.Entity.Common
{
    public class Category : BaseClass
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Priority
        /// </summary>
        public string Priority { get; set; }

        public List<SubCategory> SubCategories { get; set; }

        public Category()
        {
            SubCategories = new List<SubCategory>();
        }
    }
}