﻿using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class PermissionsSearchDto : SearchPagingModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
