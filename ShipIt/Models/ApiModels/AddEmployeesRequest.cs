﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipIt.Models.ApiModels
{
    public class AddEmployeesRequest
    {
        public List<Employee> Employees { get; set; }
    }
}