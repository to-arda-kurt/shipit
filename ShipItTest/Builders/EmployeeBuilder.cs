﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShipIt.Models.ApiModels;
using ShipIt.Models.DataModels;

namespace ShipItTest.Builders
{
    public class EmployeeBuilder
    {
        private String Name = "Gissell Sadeem";
        private int WarehouseId = 1;
        private EmployeeRole Role = EmployeeRole.OPERATIONS_MANAGER;
        private String Ext = "73996";

        public EmployeeBuilder setName(String name)
        {
            this.Name = name;
            return this;
        }

        public EmployeeBuilder setWarehouseId(int warehouseId)
        {
            this.WarehouseId = warehouseId;
            return this;
        }

        public EmployeeBuilder setRole(EmployeeRole role)
        {
            this.Role = role;
            return this;
        }

        public EmployeeBuilder setExt(String ext)
        {
            this.Ext = ext;
            return this;
        }

        public EmployeeDataModel CreateEmployeeDataModel()
        {
            return new EmployeeDataModel()
            {
                Name = this.Name,
                WarehouseId = this.WarehouseId,
                Role = this.Role.ToString(),
                Ext = this.Ext
            };
        }

        public Employee CreateEmployee()
        {
            return new Employee() {
                Name = this.Name,
                WarehouseId = this.WarehouseId,
                role = this.Role,
                ext = this.Ext
            };
        }

        public AddEmployeesRequest CreateAddEmployeesRequest()
        {
            return new AddEmployeesRequest()
            {
                Employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Name = this.Name,
                        WarehouseId = this.WarehouseId,
                        role = this.Role,
                        ext = this.Ext
                    }
                }
            };
        }
    }
}
