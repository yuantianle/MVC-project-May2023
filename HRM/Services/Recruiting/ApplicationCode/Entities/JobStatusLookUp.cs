﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCode.Entities
{
    public class JobStatusLookUp
    {
        //Open, Pending, Closed, Postponed
        public int? Id { get; set; }
        public string JobStatusCode { get; set; }
        public string JobStatusDescription { get; set; }
    }
}
