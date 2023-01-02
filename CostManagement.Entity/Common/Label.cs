using CostManagement.Entity.Shared;

namespace CostManagement.Entity.Common
{
    public class Label : BaseClass
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
    }
}