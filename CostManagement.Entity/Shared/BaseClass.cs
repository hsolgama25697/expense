using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostManagement.Entity.Shared
{
    public class BaseClass
    {
        /// <summary>
        /// CreatedBy
        /// </summary>
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public string CreatedDate { get; set; }

        /// <summary>
        /// UpdatedBy
        /// </summary>
        public Guid UpdatedBy { get; set; }

        /// <summary>
        /// UpdatedDate
        /// </summary>
        public string UpdatedDate { get; set; }
    }
}
