﻿using CostManagement.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CostManagement.Entity.API.Request
{
    public class CategoryRequest : BaseRequest
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }
        public CategoryRequest()
        {
            Category = new Category();
        }
    }
}
