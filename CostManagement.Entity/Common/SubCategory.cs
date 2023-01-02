using CostManagement.Entity.Shared;

namespace CostManagement.Entity.Common
{
    public class SubCategory : BaseClass
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
        /// CategoryId
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Priority
        /// </summary>
        public string Priority { get; set; }
    }
}