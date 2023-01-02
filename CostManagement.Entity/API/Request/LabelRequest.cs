using CostManagement.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CostManagement.Entity.API.Request
{
    public class LabelRequest 
    {
        public Label Label { get; set; }
        public LabelRequest()
        {
            Label = new Label();
        }
    }
}
